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
watch1 = watches("Xiaomi", "mi band2", 100, "2016")
print(watch1.short_description)
print(watch1.full_description())
print("\n")


watch2 = watches("Xiaomi", "mi band3", 200, "2018")
print(watch2.short_description)
print(watches.full_description(watch2))
print("\n")


watch3 = watches("Xiaomi", "mi band4", 300, "2019")
print(watch3.short_description)
print(watches.full_description(watch3))
print("\n")
watch3.apply_rising()
print("Changed price for watch3 " + watch3.marka + " " + watch3.model + " is " + str(watch3.price) + "$")
print("\n")
print("Number of watches: " + str(watches.number_of_watches))