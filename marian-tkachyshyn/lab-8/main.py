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


class Clients(Devices):
    def __init__(self, firm, price, model, resolution, cpu, gpu, client):
        super().__init__(firm, price, model, resolution, cpu, gpu)
        self.client = client


class Sellers(Devices):
    def __init__(self, firm, price, model, resolution, cpu, gpu, clients=None):
        super().__init__(firm, price, model, resolution, cpu, gpu)
        if clients is None:
            self.clients = []
        self.clients = clients

    def add_client(self, client):
        if client not in self.clients:
            self.clients.append(client)

    def remove_client(self, client):
        if client in self.clients:
            self.clients.remove(client)

    def print_clients(self):
        for client in self.clients:
            print('-->', client.short_description)


asus_client_1 = Clients('Lenovo', 700, 'G58', '1920x1080', 'Ryzen 2400', 'Vega 11', 'Petro Petrovich')
asus_client_2 = Clients('Lenovo', 350, 'L340', '1920x1080', 'Intel Core I5-9400H', 'GTX 1050', 'Ivan Ivanov')

print('\n******************/ adding two clients to Lenovo seller with different methods /******************\n')
lenovo_seller = Sellers('Lenovo', 1000, 'from IdeaPad to ThinkPad models', 'full hd', 'AMD/Intel',
                        'AMD/Nvidia', [asus_client_1])
lenovo_seller.add_client(asus_client_2)
lenovo_seller.print_clients()

print('\n******************/ after remove 1 client /******************\n')
lenovo_seller.remove_client(asus_client_1)
lenovo_seller.print_clients()

print('\n******************/ using isinstance() and issubclass() /******************\n')
print('isinstance(asus_client_1, Clients) --> ', isinstance(asus_client_1, Clients))
print('issubclass(Sellers, Devices) --> ', issubclass(Sellers, Devices))
print('issubclass(Sellers, Clients) --> ', issubclass(Sellers, Clients))

