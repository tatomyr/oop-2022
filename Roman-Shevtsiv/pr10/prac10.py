class watches:
    rising_prices = 200
    number_of_watch = 0

    def __init__(self, marka, model, price, year):
        self.marka = marka
        self.model = model
        self.price = price
        self.year = year

        watches.number_of_watch += 1

    def full_description(self):
        return "Marka and model: " + self.marka + " " + self.model + ";\nprice: " + str(self.price)

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


watch = watches('Xiaomi', 'mi band2', '100$', '2016')
watch.model = 'Mi'
print(watch.model)
print(watch.short_description)
# setter
second_watch = watches('Xiaomi', 'mi band3', '200$', '2018')
second_watch.short_description = 'Xiaomi_Mi3_200$'
print('\n' + second_watch.marka)
print(second_watch.short_description)
# deleter
print('\n')
del second_watch.short_description
print(second_watch.short_description)