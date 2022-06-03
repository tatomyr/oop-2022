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
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price) + "$\nresolution: " \
               + self.resolution + "\fuel: " + self.fuel 
    def apply_rising(self):
        self.price = self.price + self.rising_prices
    def __repr__(self):
        return "Car('{}', '{}', '{}', '{}', '{}')".format(self.marka,  self.model, self.price, self.year,self.fuel)
    def __str__(self):
        return '{} - {}'.format(self.short_description, self.year)
    def __add__(self, other):
        return self.price + other.price
first_car = Auto('Fiat', '500', 3000, '2017', 'benzin 95')
second_car = Auto('Nissan', 'Xtral', 4000,'2014', 'diesel')
print('\n- вивід інформацію про авто за допомогою магічних методів __repr__ та __str__ ')
print('repr --> ', repr(first_car))
print('str --> ', first_car)

print('\n- магічний метод __add__ ')
print('first_car + second_car(price)--> ', str(first_car + second_car)+'$')
