class watches:
    rising_prices = 50
    number_of_watches = 0

    def __init__(self, marka, model, price, year):
        self.marka = marka
        self.model = model
        self.price = price
        self.year = year
        self.short_description = marka + " " + model + ";" + str(price) + "$"
        watches.number_of_watches += 1

    def full_description(self):
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price) + "$\nyear: " \
               + self.year

    def apply_rising(self):
        self.price = self.price + self.rising_prices
    def __repr__(self):
        return "watch('{}', '{}', '{}', '{}')".format(self.marka,  self.model, self.price, self.year)
    def __str__(self):
        return '{} - {}'.format(self.short_description, self.year)
    def __add__(self, other):
        return self.price + other.price
first_watch = watches('Xiaomi', 'mi band2', 100, '2016')
second_watch = watches('Xiaomi', 'mi band3', 200,'2018')
print('\n- вивід інформацію про авто за допомогою магічних методів __repr__ та __str__ ')
print('repr --> ', repr(first_watch))
print('str --> ', first_watch)

print('\n- магічний метод __add__ ')
print('first_watch + second_watch(price)--> ', str(first_watch + second_watch)+'$')