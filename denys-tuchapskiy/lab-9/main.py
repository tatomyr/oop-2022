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

    def __repr__(self):
        return "Device('{}', '{}', '{}', '{}', '{}', '{}')".format(self.firm, self.price, self.model, self.resolution,
                                                                   self.cpu, self.gpu)

    def __str__(self):
        return '{} - {}'.format(self.short_description, self.resolution)

    def __add__(self, other):
        return self.price + other.price


first_device = Devices('Lenovo', 500, 'L340', '1920x1080', 'Intel Core I5-9300H', 'Nvidia GTX 1050')
second_device = Devices('Asus', 230, 'L340', '1920x1080', 'Intel Core I5-9300H', 'Nvidia GTX 1050')

print('\n***************** print info about device with __repr__ and __str__ magic method *****************')
print('repr --> ', repr(first_device))
print('str --> ', first_device)

print('\n***************** magic method __add__ *****************')
print('first_device + second_device (prices) --> ', str(first_device + second_device) + '$')
