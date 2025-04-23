/*  CSE 381 - Huffman Tree Test
 *  (c) BYU-Idaho - It is an honor code violation to post this
 *  file completed in a public file sharing site.
 *
 *  Instructions: Do not modify this file.  Use these test to verify
 *  that your code is working properly.
*/
#pragma warning disable CS8602   // Dereference of a possibly null reference.

using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class HuffmanTreeTest
{
    
    [Test]
    public void Test1_Profile()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var expected = new List<(char,int)> {
            (' ', 8),
            ('a', 5),
            ('e', 2),
            ('h', 2),
            ('i', 6),
            ('l', 2),
            ('m', 1),
            ('n', 6),
            ('p', 2),
            ('r', 1),
            ('s', 3),
            ('t', 3),
            ('y', 2)
        };
        Assert.That(profile, Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void Test2_BuildTree()
    {
        var text = "aabbbccccdde";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        Assert.That(tree.Count, Is.EqualTo(12));
        Assert.That(tree.Left.Count, Is.EqualTo(5));
        Assert.That(tree.Left.Left.Count, Is.EqualTo(2));
        Assert.That(tree.Left.Left.Letter, Is.EqualTo('a'));
        Assert.That(tree.Left.Left.Left, Is.EqualTo(null));
        Assert.That(tree.Left.Left.Right, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Count, Is.EqualTo(3));
        Assert.That(tree.Left.Right.Left.Count, Is.EqualTo(1));
        Assert.That(tree.Left.Right.Left.Letter, Is.EqualTo('e'));
        Assert.That(tree.Left.Right.Left.Left, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Left.Right, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Right.Count, Is.EqualTo(2));
        Assert.That(tree.Left.Right.Right.Letter, Is.EqualTo('d'));
        Assert.That(tree.Left.Right.Right.Left, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Right.Right, Is.EqualTo(null));
        Assert.That(tree.Right.Count, Is.EqualTo(7));
        Assert.That(tree.Right.Left.Count, Is.EqualTo(3));
        Assert.That(tree.Right.Left.Letter, Is.EqualTo('b'));
        Assert.That(tree.Right.Left.Left, Is.EqualTo(null));
        Assert.That(tree.Right.Left.Right, Is.EqualTo(null));
        Assert.That(tree.Right.Right.Count, Is.EqualTo(4));
        Assert.That(tree.Right.Right.Letter, Is.EqualTo('c'));
        Assert.That(tree.Right.Right.Left, Is.EqualTo(null));
        Assert.That(tree.Right.Right.Right, Is.EqualTo(null));
        
        Assert.Pass();
    }
    
    [Test]
    public void Test3_CreateEncodingMap()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        var map = HuffmanTree.CreateEncodingMap(tree);
        Assert.That(map['l'], Is.EqualTo("11101"));
        Assert.That(map['e'], Is.EqualTo("11111"));
        Assert.That(map['h'], Is.EqualTo("11110"));
        Assert.That(map['r'], Is.EqualTo("01011"));
        Assert.That(map['m'], Is.EqualTo("01010"));
        Assert.That(map['p'], Is.EqualTo("0100"));
        Assert.That(map['y'], Is.EqualTo("11100"));
        Assert.That(map['a'], Is.EqualTo("011"));
        Assert.That(map['s'], Is.EqualTo("1001"));
        Assert.That(map['t'], Is.EqualTo("1000"));
        Assert.That(map['n'], Is.EqualTo("101"));
        Assert.That(map['i'], Is.EqualTo("110"));
        Assert.That(map[' '], Is.EqualTo("00"));
        Assert.That(map.Count, Is.EqualTo(13));
        Assert.Pass();

    }
    
    [Test]
    public void Test4_Encode()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        var map = HuffmanTree.CreateEncodingMap(tree);
        var encoded = HuffmanTree.Encode(text, map);
        Assert.That(encoded, Is.EqualTo("10001111011111000101101111010100110101001001010001111010100100110000111110010010001010011110101111011110000110101001000111101111100010011101011110101"));
        Assert.Pass();

    }

    [Test]
    public void Test5_Decode()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        var map = HuffmanTree.CreateEncodingMap(tree);
        var encoded = HuffmanTree.Encode(text, map);
        var decoded = HuffmanTree.Decode(encoded, tree);
        Assert.That(decoded, Is.EqualTo("the rain in spain stays mainly in the plain"));
        Assert.Pass();

    }
}

#pragma warning restore CS8602  // Dereference of a possibly null reference.