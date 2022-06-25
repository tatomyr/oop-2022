class baking:
    rising_prices = 5
    number_of_baking = 0
    def __init__(self, filling, name, price, date):
        self.filling = filling
        self.name = name
        self.price = price
        self.date = date

        baking.number_of_baking += 1

    def full_description(self):
        return "filling and name: " + self.filling + " " + self.name + ";\nprice: " + str(self.price) + "$\ndate of manufacture : " \
               + self.date


    @property
    def short_description(self):
        return '{} {}; {}'.format(self.filling, self.name, self.price)

    @short_description.setter
    def short_description(self, type):
        filling, name , price = type.split('_')
        self.filling = filling
        self.name = name
        self.price = price

    @short_description.deleter
    def short_description(self):
        print('Delete type!')
        self.filling = None
        self.name = None
        self.price = None
        # property decorator


baking1 = baking("chocolate", "donat", '15', "25.06.2022")
baking1.name = 'donat'
print(baking1.name)
print(baking1.short_description)
# setter
second_baking = baking("nut", "nutcake", 20, "25.06.2022")
second_baking.short_description = 'nut_nutcake_20$'
print('\n' + second_baking.filling)
print(second_baking.short_description)
# deleter
print('\n')
del second_baking.short_description
print(second_baking.short_description)