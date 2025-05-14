# CSE 381 REPL4B
# Counting Sort

def CreateEquals(data, rangeData):
    equals = [0] * rangeData
    for x in data:
        equals[x] += 1
    return equals

def CreateOrder(equals, rangeData):
    order = [0] * rangeData
    # note: order[0] is equal to 0
    for index in range(1,rangeData):
        order[index] = order[index - 1] + equals[index - 1]
    return order

def Sort(data, rangeData):
    equals = CreateEquals(data, rangeData)
    order = CreateOrder(equals, rangeData)
    sorted = [0] * len(data)
    for x in data:
        sorted[order[x]] = x
        order[x] += 1
    return sorted

data = [1,0,2,1,3,3,2,4,1,0]
sorted = Sort(data, 10) # range 0 - 9
for x in sorted:
    print(x)