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


computer_1 = Devices("Phoenix", 1000, "M83", "1920x1080", "Intel core I5 8400", "GTX 1060 6GB")
print(computer_1.short_description)
print("\n")
print(computer_1.full_description())

print("\n")

phone_1 = Devices("Xiaomi", 150, "Redmi Note 9 Pro", "1920x1080", "Snapdragon 832", "Helio A12")
print(phone_1.short_description)
print("\n")
print(Devices.full_description(phone_1))

print("\n")
phone_1.apply_rising()
print("Changed price for phone " + phone_1.firm + " " + phone_1.model + " is " + str(phone_1.price) + "$")

print("\n")
print("Number of devices: " + str(Devices.number_of_devices))
