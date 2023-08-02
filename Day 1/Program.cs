// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

namespace Day1
{
    class Program {

        static void Main(string[] args)
        {
            Conosle.WriteLine("Enter a word");
            var word = Console.ReadLine();
            Conosle.WriteLine(isPalindrome(word));
            
    }

    static bool isPalindrome(string word){
       
  int i = 0;
  int j= 0;

  while (i<=j){
    if(word[i] == word[j]){
      i ++;
      j--;
    }
    else{
      return false;
    }
  }
       return true;
 
  
    }

    
}}