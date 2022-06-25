class watches:
    rising_prices = 50
    number_of_watches = 0

    def __init__(self, marka, model, price, year):
        self.marka = marka
        self.model = model
        self.price = price
        self.year = year
        self.short_description = marka + " " + model + "; " + str(price) + "$"
        watches.number_of_watches += 1

    def full_description(self):
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price) + "$\nyear: " \
               + self.year

    def apply_rising(self):
        self.price = self.price + self.rising_prices

class Clients(watches):
    def __init__(self, marka, model, price, year, client):
        super().__init__(marka, model, price, year)
        self.client = client


class Sellers(watches):
    def __init__(self, marka, model, price, year, clients=None):
        super().__init__(marka, model, price, year)
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

first_Xiaomi_client = Clients('Xiaomi', 'mi band2', 100, '2016', 'Zhovniriv L.')
second_Xiaomi_client = Clients('Xiaomi', 'mi band3', 200, '2018',  'Shevtsiv R.')
print('\n*/ adding two clients to Xiaomi seller with different methods /*\n')
Xi_seller = Sellers('Xiaomi', '200', '2018', [first_Xiaomi_client])
Xi_seller.add_client(second_Xiaomi_client)
Xi_seller.print_clients()