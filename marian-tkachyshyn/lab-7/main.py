class Devices:
    rising_prices = 50
    number_of_devices = 0

    def __init__(self, firm, price, model, resolution, cpu, gpu):
        self.firm = firm
        self.price = price
        self.model = model
        self.resolution = resolution
        self.cpu = cpu
        self.gpu = gpu
        self.short_description = firm + " " + model + "; " + str(price) + "$"
        Devices.number_of_devices += 1

    def full_description(self):
        return "Firm and model: " + self.firm + " " + self.model + ";\nprice: " + str(self.price) + "$\nresolution: " \
               + self.resolution + "\nCPU: " + self.cpu + "\nGPU: " + self.gpu

    def apply_rising(self):
        self.price = self.price + self.rising_prices

    @classmethod
    def from_string(cls, dev_str):
        firm, price, model, resolution, cpu, gpu = dev_str.split("-")
        return cls(firm, price, model, resolution, cpu, gpu)

    @classmethod
    def set_price_device(cls, dev_price):
        cls.rising_prices = dev_price

    @staticmethod
    def is_low_price(price):
        if price < 200:
            return True
        return False


dev_str_1 = "Asus-1200-M83-1920x1080-Intel Core I5 9400H-GTX 1650"
new_dev_1 = Devices.from_string(dev_str_1)
print(new_dev_1.short_description)

notebook_1 = Devices("Lenovo", 600, "H81", "1920x1080", "Intel Core I5 8400", "GTX 1060")
Devices.set_price_device(1000)
print(notebook_1.rising_prices)

print(Devices.is_low_price(notebook_1.price))

