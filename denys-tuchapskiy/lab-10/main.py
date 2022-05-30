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
        Devices.number_of_devices += 1

    def full_description(self):
        return "Firm and model: " + self.firm + " " + self.model + ";\nprice: " + str(self.price) + "$\nresolution: " \
               + self.resolution + "\nCPU: " + self.cpu + "\nGPU: " + self.gpu

    @property
    def short_description(self):
        return '{} {}; {}'.format(self.firm, self.model, self.resolution)

    @short_description.setter
    def short_description(self, type):
        firm, model, resolution = type.split('_')
        self.firm = firm
        self.model = model
        self.resolution = resolution

    @short_description.deleter
    def short_description(self):
        print('Delete type!')
        self.firm = None
        self.model = None
        self.resolution = None


# property decorator
device = Devices('Lenovo', 150, '81LK', '1920x1080', 'I5-9300H', 'GTX 1050')
device.model = 'L340-15IRH'
print(device.model)
print(device.short_description)

# setter
second_device = Devices('Lenovo', 200, '81LK', '1920x1080', 'I5-9400', 'GTX 1060 6GB')
second_device.short_description = 'MacBook_Pro 16 M1_3456x2234'
print('\n' + second_device.firm)
print(second_device.short_description)

# deleter
print('\n')
del second_device.short_description
print(second_device.short_description)