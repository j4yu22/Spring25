# CSE 381 REPL 8B Solution
# String Matcher

def build_fsm(pattern, inputs):
    table = []
    for k in range(len(pattern)+1):
        map = {}
        for a in inputs:
            pka = pattern[:k] + a
            i = min(k+1, len(pattern))
            while not pka.endswith(pattern[:i]):
                i -= 1
            map[a] = i
        table.append(map)
    return table
                

def match_pattern(text, pattern, inputs):
    table = build_fsm(pattern, inputs)
    match_state = len(table) - 1
    state = 0
    results = []
    for index in range(len(text)):
        state = table[state][text[index]]
        if state == match_state:
            results.append(index)
    return results

results = match_pattern("ABCBCABCBCBC", "CBC", ["A","B","C"])
print(results) # [4,9,11]

results = match_pattern("GTAACAGTAAACG", "AAC", ["A","C","G","T"])
print(results) # [4,11]

results = match_pattern("GTAACTAACTAGTAAACAAACTG","AACT",["A","C","G","T"])
print(results) # [5,9,21]

results = match_pattern("GTAACAGTAAACG","AACT",["A","C","G","T"])
print(results) # []