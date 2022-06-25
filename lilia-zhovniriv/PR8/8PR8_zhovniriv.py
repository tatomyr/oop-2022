class baking:
    rising_prices = 5
    number_of_baking = 0
    def __init__(self, filling, name, price, date):
        self.filling = filling
        self.name = name
        self.price = price
        self.date = date
        self.short_description = filling + " " + name + "; " + str(price) + "$"
        baking.number_of_baking += 1

    def full_description(self):
        return "filling and name: " + self.filling + " " + self.name + ";\nprice: " + str(self.price) + "$\ndate of manufacture : " \
               + self.date

    def apply_rising(self):
        self.price = self.price + self.rising_prices

class Clients(baking):
    def __init__(self, filling, name, price, date, client):
        super().__init__(filling, name, price, date)
        self.client = client


class Sellers(baking):
    def __init__(self, filling, name, price, date, clients=None):
        super().__init__(filling, name, price, date)
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

first_baking_client = Clients("chocolate", "donat", 15, "25.06.2022", 'Tokar V.')
second_baking_client = Clients("nut", "nutcake", 20, "25.06.2022",  'Shevtsiv R.')
print('\n*/ adding two clients to baking seller with different methods /*\n')
ba_seller = Sellers('Xiaomi', '200', '2018', [first_baking_client])
ba_seller.add_client(second_baking_client)
ba_seller.print_clients()
