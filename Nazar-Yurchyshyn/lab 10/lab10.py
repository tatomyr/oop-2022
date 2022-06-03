class Auto:
    rising_prices = 200
    number_of_auto = 0

    def __init__(self, marka, model, price, year, fuel):
        self.marka = marka
        self.model = model
        self.price = price
        self.year = year
        self.fuel = fuel

        Auto.number_of_auto += 1

    def full_description(self):
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price) + "$\nresolution: " \
               + self.resolution + "\fuel: " + self.fuel

    @property
    def short_description(self):
        return '{} {}; {}'.format(self.marka, self.model, self.price)

    @short_description.setter
    def short_description(self, type):
        marka, model, price = type.split('_')
        self.marka = marka
        self.model = model
        self.price = price

    @short_description.deleter
    def short_description(self):
        print('Delete type!')
        self.marka = None
        self.model = None
        self.price = None
        # property decorator


car = Auto('Fiat', '500', '3000$', '2017', 'benzin 95')
car.model = 'doblo'
print(car.model)
print(car.short_description)
# setter
second_car = Auto('Fiat', '500', '3000$', '2017', 'benzin 95')
second_car.short_description = 'Nissan_RX _8000$'
print('\n' + second_car.marka)
print(second_car.short_description)
# deleter
print('\n')
del second_car.short_description
print(second_car.short_description)