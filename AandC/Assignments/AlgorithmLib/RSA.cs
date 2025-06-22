/* CSE 381 - RSA 
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S5.
*
*  Instructions: Implement the Euclid, ModularExponentiation, GeneratePrivateKey,
*  Encrypt, and Decrypt functions per the instructions in the comments.  
*  Run all tests in RSATest.cs to verify your code.
*/

using System.Numerics;

namespace AlgorithmLib;

public class RSA
{
    /* Recursively use Euclid to find the Greatest Common Divisor between
     * two numbers as well as the linear combination form.
     *
     *  Inputs:
     *     a - First number
     *     b - Second number
     *  Outputs:
     *     (gcd, i, j) where gcd = i*a + j*b
     */
    public static (BigInteger, BigInteger, BigInteger) Euclid(BigInteger a, BigInteger b)
    {
        // base case: gcd(a, 0) = a
        if (b == 0)
            return (a, 1, 0);

        // recursive call
        var (gcd, x1, y1) = Euclid(b, a % b);
        // update coefficients using previous results
        BigInteger x = y1;
        BigInteger y = x1 - (a / b) * y1;

        return (gcd, x, y);
    }

    /* Recursively calculates x^y mod n
     *
     *  Inputs:
     *     x - base
     *     y - exponent
     *     n - modulo
     *  Outputs:
     *     Result of x^y mod n
     */
    public static BigInteger ModularExponentiation(BigInteger x, BigInteger y, BigInteger n)
    {
        // base case: anything to the power 0 is 1
        if (y == 0)
            return 1;
        // recursively compute half the power
        BigInteger z = ModularExponentiation(x, y / 2, n);
        // square the result
        BigInteger result = (z * z) % n;

        // if exponent is odd, multiply one more time by base
        if (y % 2 == 1)
            result = (result * x) % n;

        return result;
    }

    /* Generate the RSA private key given the two prime numbers p and q and
     * the public key e which was selected to be co-prime with
     * phi = (p-1) * (q-1).
     * 
     *  Inputs:
     *     p - First prime
     *     q - Second prime
     *     e - Public Key 
     *  Outputs:
     *     Private Key - Must be positive
     */
    public static BigInteger GeneratePrivateKey(BigInteger p, BigInteger q, BigInteger e) 
    {
        // compute phi
        BigInteger phi = (p - 1) * (q - 1);
        // use extended euclidean algorithm to get inverse of e mod phi
        var (gcd, d, _) = Euclid(e, phi);

        // make sure private key is positive
        if (d < 0)
            d += phi;

        return d;
    }

    /* Encrypt a value using the public keys e and n
     *
     *  Inputs:
     *     value - Value to encrypt
     *     e - Public Key whose value was co-prime with phi
     *     n - Public Key whose Value is equal to p*q
     *  Outputs:
     *     encrypted value
     */
    public static BigInteger Encrypt(BigInteger value, BigInteger e, BigInteger n)
    {
        // encrypt using modular exponentiation: value^e mod n
        return ModularExponentiation(value, e, n);
    }

    /* Decrypt a value using the public key n and private key d
     *
     *  Inputs:
     *     value - Value to decrypt
     *     d - Private Key whose value was the multiplicative inverse of e mod phi
     *     n - Public Key whose Value is equal to p*q
     *  Outputs:
     *     encrypted value
     */
    public static BigInteger Decrypt(BigInteger value, BigInteger d, BigInteger n)
    {
        // decrypt using modular exponentiation: value^d mod n
        return ModularExponentiation(value, d, n);
    }
}