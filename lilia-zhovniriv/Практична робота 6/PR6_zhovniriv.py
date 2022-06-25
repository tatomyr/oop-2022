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
baking1 = baking("chocolate", "donat", 15, "25.06.2022")
print(baking1.short_description)
print(baking1.full_description())
print("\n")


baking2 = baking("nut", "nutcake", 20, "25.06.2022")
print(baking2.short_description)
print(baking.full_description(baking2))
print("\n")


baking3 = baking("ice cream", "croissant", 30, "25.06.2022")
print(baking3.short_description)
print(baking.full_description(baking3))
print("\n")
baking3.apply_rising()
print("Changed price for baking3 " + baking3.filling + " " + baking3.name + " is " + str(baking3.price) + "$")
print("\n")
print("Number of baking: " + str(baking.number_of_baking))
