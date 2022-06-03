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


computer_first = Devices("Asus", 1200, "M83", "1920x1080", "Intel core I5", "GTX 1650")
print(computer_first.short_description)
print("\n")
print(computer_first.full_description())

print("\n")

phone_first = Devices("Lenovo", 199.99, "Moto G22", "1440x720", "Snapdragon 832", "PowerVR GE8320")
print(phone_first.short_description)
print("\n")
print(Devices.full_description(phone_first))

print("\n")
phone_first.apply_rising()
print("Changed price for phone " + phone_first.firm + " " + phone_first.model + " is " + str(phone_first.price) + "$")

print("\n")
print("Number of devices: " + str(Devices.number_of_devices))
