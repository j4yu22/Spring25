# CSE 381 REPL 8B
# String Matcher

def build_fsm(pattern, inputs):
    pass
    
def match_pattern(text, pattern, inputs):
    table = build_fsm(pattern, inputs)
    

results = match_pattern("ABCBCABCBCBC", "CBC", ["A","B","C"])
print(results) # [4,9,11]

results = match_pattern("GTAACAGTAAACG", "AAC", ["A","C","G","T"])
print(results) # [4,11]

results = match_pattern("GTAACTAACTAGTAAACAAACTG","AACT",["A","C","G","T"])
print(results) # [5,9,21]

results = match_pattern("GTAACAGTAAACG","AACT",["A","C","G","T"])
print(results) # []