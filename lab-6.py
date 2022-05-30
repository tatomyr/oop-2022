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
               + self.year + "\nfuel: " + self.fuel

    def apply_rising(self):
        self.price = self.price + self.rising_prices
car1 = Auto("Nissan", "X-tral", 4000, "2014", "diesel")
print(car1.short_description)
print(car1.full_description())
print("\n")
car2 = Auto("Fiat", "500", 3000, "2017", "benzin 95")
print(car2.short_description)
print(Auto.full_description(car2))
print("\n")
car3 = Auto("Ford", "F-350", 50000, "2018", "benzin 100")
print(car3.short_description)
print(Auto.full_description(car3))
print("\n")
print("\n")
car1.apply_rising()
print("Changed price for car1 " + car1.marka + " " + car1.model + " is " + str(car1.price) + "$")
print("\n")
print("Number of auto: " + str(Auto.number_of_auto))
