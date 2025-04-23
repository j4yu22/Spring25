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
        return (0,0,0);
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
        return 0;
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
        return 0;
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
        return 0;
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
        return 0;
    }


}