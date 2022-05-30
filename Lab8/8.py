class Auto:
    rising_prices = 200
    number_of_auto = 0

    def __init__(self, marka, model, price, year, fuel):
        self.marka = marka
        self.model = model
        self.price = price
        self.year = year
        self.fuel = fuel
        self.short_description = marka + " " + model + "; " + str(price) + "$"
        Auto.number_of_auto += 1

    def full_description(self):
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price) + "$\nyear: " \
 + self.year +    "\nfuel: " + self.fuel

    def apply_rising(self):
        self.price = self.price + self.rising_prices

class Clients(Auto):
    def __init__(self, marka, model, price, year, fuel, client):
        super().__init__(marka, model, price, year, fuel)
        self.client = client


class Sellers(Auto):
    def __init__(self, marka, model, price, year, fuel, clients=None):
        super().__init__(marka, model, price, year, fuel)
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

first_nissan_client = Clients('Nissan', 'X-tral', 4000, '2014','diesel', 'Nazar Y.')
second_nissan_client = Clients('Nissan', 'Juke', 3000, '2017', 'benzin 95', 'Ilon M.')
print('\n*/ adding two clients to Nissan seller with different methods /*\n')
nis_seller = Sellers('Nissan', 1000, '2015','full hd','disel', [first_nissan_client])
nis_seller.add_client(second_nissan_client)
nis_seller.print_clients()
