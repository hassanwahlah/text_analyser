internal class Program
{
    static bool IsPresent(string key, string[,] freq_arr, int length){

        for(int i=0; i<length; i++)
        {
            for(int j=0; j<2; j++)
            {
                if (freq_arr[i,j] == key){
                    return true;
                }
            }
        }
        return false;

    }

    static int uniqueWord(string[] temp_arr){
        string [] unique_words = new string[temp_arr.Length];
        int m = 0;
        for(int i=0; i<temp_arr.Length; i++){
            string word_to_check = temp_arr[i];
            if(m==0){
                unique_words[m] = word_to_check;
                m++;
            }
            bool present = false;
            for(int j=0; j<m; j++){
                if(unique_words[j] == word_to_check){
                    present = true;
                }
            }
            if(present == false){
                unique_words[m++] = word_to_check;
            }
        }
        return m+1;
    }

    static string[,] WordFrequencyAnalysis(string senInput)
    {
        string[] temp_arr = senInput.Split(" ");
        int unique_count = uniqueWord(temp_arr);
        Console.WriteLine(unique_count);
        string[,] freq_arr = new string [unique_count, 2];

        for(int i=0; i<unique_count; i++){
            string word_to_check = temp_arr[i];
            int freq = 1;
            bool present = IsPresent(word_to_check, freq_arr, unique_count);
            if (present == false){
                for(int j=0; j<temp_arr.Length; j++){
                    if(i!= j){
                        if(word_to_check == temp_arr[j]){
                            freq = freq + 1;
                        }
                    }
                }
                freq_arr[i,0] = word_to_check;
                freq_arr[i,1] = freq.ToString();
            }
        }

        return freq_arr;
    }

 static void SentenceMaker(string senInput, int N)
 {
    string[] temp_arr = senInput.Split(" ");
    string[,] shuffled_arr = new string [N, temp_arr.Length];
    Random random = new Random();

    for(int i=0; i<N; i++)
    {
        for(int j=0; j<temp_arr.Length; j++)
        {
            int index = random.Next(0, temp_arr.Length);
            shuffled_arr[i, j] = temp_arr[index];
        }
    }
    for(int i=0; i<N; i++)
    {
        for (int j=0; j<temp_arr.Length; j++)
        {
            Console.Write(shuffled_arr[i,j] + (" "));
        }
        Console.WriteLine();
    }

 }


static void LongestandShortestWordFinder(string senInput)
{
    string[] newstr = senInput.Split(" ");
    string[] arr = new string[newstr.Length];

    for(int i=0; i<newstr.Length; i++)
    {
        Console.WriteLine(newstr[i] + ": " + newstr[i].Length);
        arr[i] = newstr[i];
    }
    

    int max = 0;
    int min = arr[0].Length;
    string maximum = "";
    string minimum = "";
    for(int i=0; i<arr.Length; i++)
    {
        if(max < arr[i].Length)
        {
            max = arr[i].Length;
            maximum = arr[i];
            
        }
        
        
        if(min > arr[i].Length)
        {
            min = arr[i].Length;
            minimum = arr[i];
        }
        
    }
    Console.WriteLine("Longest word(s) is: " + maximum);
    Console.WriteLine("Shortest word(s) is: " + minimum);
}

static void WordSearch(string senInput)
{
    Console.WriteLine("Please enter the word to search");
    string word = (Console.ReadLine());
    
    string[] newstr = senInput.Split(" ");
    int count = 0;
    for(int i=0; i<newstr.Length; i++)
    {
        if(word == newstr[i])
        {
            count++;
        }
    }
    Console.WriteLine("The word '" +  word + "' appears " + count + " time(s) in a sentence");
}

static bool IsPalindrome(string str)
{
    int left = 0;
    int right = str.Length-1;
    while(left < right)
    {
        if(str[left] != str[right])
        {
            return false;
        }
        left++;
        right--;
    }
    return true;
}

static void PalindromeDetector(string senInput)
{
    string[] newstr = senInput.Split(" ");
    int check = 0;
    for(int i=0; i<newstr.Length; i++)
    {
        if(IsPalindrome(newstr[i]) == true)
        {
            Console.WriteLine("The word " + newstr[i] + " is Palindrome");
            check = 1;
        } 
    }
    if(check == 0)
    {
        Console.WriteLine("There are no Palindrom words in the sentence");
    }
    
}

static void VovelConsonent(string abc)
{
    int vovel = 0;
    int consonent = 0;

    
   for(int i=0; i<abc.Length; i++)
   
    {
       if(abc[i] == 'A' || abc[i] == 'a' || abc[i] == 'E' || abc[i] == 'e' || abc[i] == 'I' || abc[i] == 'i' || abc[i] == 'O' || abc[i] == 'o' || abc[i] == 'U' || abc[i] == 'u')
       {
        vovel++;
       } else
       {
        consonent++;
       }
       
    }
    Console.WriteLine(abc + ": " + vovel + " vovel(s) and " + consonent +" consonent(s)");
}

static void VovelConsonantCounter(string senInput)
{
    string[] newstr = senInput.Split(" ");
    for(int i=0; i<newstr.Length; i++)
    {
     VovelConsonent(newstr[i]);
    }
}


    private static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Text Analyzer \nPlease enter a sentence");
        string senInput = (Console.ReadLine());
        
        Console.WriteLine("\nPlease choose the following by pressing number \n\n1. Word Frequency Analysis \n2. Sentence Maker \n3. Longest and Shortest Word Finder \n4. Word Search \n5. Palindrome Detector \n6. Vovel/Consonant Counter");
        int choice = int.Parse(Console.ReadLine());
        if(choice == 1)
        {
            string[,] freq_arr = WordFrequencyAnalysis(senInput);
            var row = freq_arr.GetLength(0);
            var col = freq_arr.GetLength(1);
            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    Console.Write(freq_arr[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
        else if(choice == 2)
        {
            Console.WriteLine("Please enter N value");
            int N = int.Parse(Console.ReadLine());
            SentenceMaker(senInput, N);
        }

        else if(choice == 3)
        {
            LongestandShortestWordFinder(senInput);
        }
        else if(choice == 4)
        {
            WordSearch(senInput);
        }
        else if(choice == 5)
        {
            PalindromeDetector(senInput);
        }
        else if(choice == 6)
        {
            VovelConsonantCounter(senInput);
        }
    }
}
