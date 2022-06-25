print("Zadacha 21")
mystring = "hello"
myfloat = 10.0
myint = 20

if mystring == "hello":
    print("String: %s" % mystring)
if isinstance(myfloat, float) and myfloat == 10.0:
    print("Float: %f" % myfloat)
if isinstance(myint, int) and myint == 20:
    print("Integer: %d" % myint)
print(" ")


print("Zadacha 22")
print(" ")
numbers = [1, 2, 3]
strings = ['hello', 'world']
names = ["John", "Eric", "Jessica"]

second_name = names[1]
print(numbers)
print(strings)
print("The second name on the names list is %s" % second_name)
print(" ")


print("Zadacha 23")
print(" ")
x = object()
y = object()
x_list = [x, x, x, x, x, x, x, x, x, x]
y_list = [y, y, y, y, y, y, y, y, y, y]
big_list = x_list + y_list

print("x_list contains %d objects" % len(x_list))
print("y_list contains %d objects" % len(y_list))
print("big_list contains %d objects" % len(big_list))
# testing code
if x_list.count(x) == 10 and y_list.count(y) == 10:
    print("Almost there...")
if big_list.count(x) == 10 and big_list.count(y) == 10:
    print("Great!")
print(" ")

print("Zadacha 24")
print(" ")
phonebook = {
    "John": 938477566,
    "Jack": 938377264,
    "Jill": 947662781
}
del phonebook["Jill"]
phonebook["Jake"] = 938273443

# testing code
if "Jake" in phonebook:
    print("Jake is listed in the phonebook.")

if "Jill" not in phonebook:
    print("Jill is not listed in the phonebook.")
