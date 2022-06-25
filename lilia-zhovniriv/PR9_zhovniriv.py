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
    def __repr__(self):
        return "baking('{}', '{}', '{}', '{}')".format( self.filling,  self.name , self.price, self.date)
    def __str__(self):
        return '{} - {}'.format(self.short_description, self.date)
    def __add__(self, other):
        return self.price + other.price
first_baking = baking("chocolate", "donat", 15, "25.06.2022")
second_baking = baking("nut", "nutcake", 20, "25.06.2022")
print('\n- вивід інформацію про авто за допомогою магічних методів __repr__ та __str__ ')
print('repr --> ', repr(first_baking))
print('str --> ', first_baking)

print('\n- магічний метод __add__ ')
print('first_baking + second_baking(price)--> ', str(first_baking + second_baking)+'$')