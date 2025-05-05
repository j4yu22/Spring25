class CalculatorLogic {
  String _expression = '';

  /// Processes input and returns updated display
  String handleInput(String input) {
    if (input == 'C') {
      _expression = '';
    } else if (input == '=') {
      _expression = _evaluateExpression();
    } else {
      _expression += input;
    }
    return _expression;
  }

  String _evaluateExpression() {
    try {
      String exp = _expression.replaceAll('x', '*');
      final result = _safeEval(exp);
      return result.toString();
    } catch (e) {
      return 'Error';
    }
  }

  double _safeEval(String expression) {
    // basic eval: no parentheses or precedence
    final tokens = expression.split(RegExp(r'(?<=[-+*/])|(?=[-+*/])'));
    double result = double.parse(tokens[0]);

    for (int i = 1; i < tokens.length; i += 2) {
      String op = tokens[i];
      double num = double.parse(tokens[i + 1]);

      switch (op) {
        case '+':
          result += num;
          break;
        case '-':
          result -= num;
          break;
        case '*':
          result *= num;
          break;
        case '/':
          result /= num;
          break;
      }
    }

    return result;
  }
}
