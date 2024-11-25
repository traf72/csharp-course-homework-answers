/******************************************************************
    1. Объявите переменные, используя строковые литералы ниже:
           - john.doe@example.com
           - +1-800-123-4567
           - 1234 Maple Street, Anytown, CA 90210
           - https://www.example.com
           - Error 403: Unauthorized
           - CSV means "Comma-separated values"
           - C:\Program Files\dotnet
       Дайте переменным осмысленные имена.
******************************************************************/

using System.Text;

string email = "john.doe@example.com";
string phone = "+1-800-123-4567";
string address = "1234 Maple Street, Anytown, CA 90210";
string website = "https://www.example.com";
string error403 = "Error 403: Unauthorized";
string csvExplanation = "CSV means \"Comma-separated values\"";
string dotnetPath = @"C:\Program Files\dotnet";


Console.WriteLine("-----------------Creating strings using constructors-----------------");

/***********************************************************************
    2. Создайте строку с помощью подходящего конструктора.

       Важно! Не рассматривайте любые конструкторы, которые принимают
              в себя указатели, то есть, аргументы со звёздочкой.
***********************************************************************/

// 2.1. Вам дан символ, и вам необходимо создать строку, которая повторяет этот символ 5 раз.

char symbol = '8';
string repeatedSymbol = new(symbol, 5);
Console.WriteLine(repeatedSymbol);

// 2.2. Вам дан массив символов, который представляет собой текст "The only limit to our realization of tomorrow is our doubts of today.".
//      Вам необходимо создать строку, которая будет содержать только часть "tomorrow is our doubts" этого массива.

char[] charArray = "The only limit to our realization of tomorrow is our doubts of today.".ToCharArray();
string substringFromCharArray = new(charArray, 37, 22);
Console.WriteLine(substringFromCharArray);


Console.WriteLine("\n-----------------String concatenation (1)-----------------");

/***********************************************************************************************************************
    3. Используя переменные из первого задания, вам нужно собрать строку, которая будет выглядеть следующим образом:
    
       "Reach me at Email: john.doe@example.com, Phone: +1-800-123-4567. Visit my website https://www.example.com."

       3.1. Используя оператор '+'.
       3.2. Используя метод "string.Concat".
       3.3. Используя метод "string.Format".
       3.4. Используя интерполяцию строк.

       Дайте переменной осмысленное имя.
***********************************************************************************************************************/

string contactInfo = "Reach me at Email: " + email + ", Phone: " + phone + ". Visit my website " + website + ".";
Console.WriteLine(contactInfo);

contactInfo = string.Concat("Reach me at Email: ", email, ", Phone: ", phone, ". Visit my website ", website, ".");
Console.WriteLine(contactInfo);

contactInfo = string.Format("Reach me at Email: {0}, Phone: {1}. Visit my website {2}.", email, phone, website);
Console.WriteLine(contactInfo);

contactInfo = $"Reach me at Email: {email}, Phone: {phone}. Visit my website {website}.";
Console.WriteLine(contactInfo);


Console.WriteLine("\n-----------------String concatenation (2)-----------------");

/************************************************************************************************
    4. Вам дан массив строк. Вам неообходимо сконкатенировать все строки этого массива в одну
       без всякого разделителя. То есть, слова в массиве уже даны с разделителем.
       В итоге у вас должна получиться фраза:
    
       "Imagination is more important than knowledge."

       Как бы вы это сделали?
************************************************************************************************/

string[] phraseParts = ["Imagination ", "is ", "more ", "important ", "than ", "knowledge."];

// Первый способ (самый простой): использовать метод "string.Concat" и просто передать ему этот массив.
Console.WriteLine(string.Concat(phraseParts));

// Второй способ: использовать метод "string.Join" с пустым разделителем.
Console.WriteLine(string.Join("", phraseParts));


Console.WriteLine("\n-----------------String concatenation with formatting-----------------");

/*************************************************************************************************************************************
    5. Вам даны дата и минимальная температура эксперимента. Вам нужно собрать строку следующего вида:

       "The experiment will take place on 2024-04-10 at 14:38:00. The temperature in Celsius should not be less than -9 degrees."

       Дата, время и значение температуры должны отображаться точно так, как указано выше.
*************************************************************************************************************************************/

DateTime experimentDate = new(2024, 4, 10, 14, 38, 0); // April 10, 2024, 14:38:00
double experimentMinTemperature = -8.6;

// Для форматирования даты необходимо применить формат "yyyy-MM-dd", для времени - "HH:mm:ss".
// Для числа можно применить формат "F0", что означает "Вывести с нулём знаков после запятой".
// Число в таком случае будет округлено до целого корректно.

// Вариант со "string.Format"
Console.WriteLine("The experiment will take place on {0:yyyy-MM-dd} at {0:HH:mm:ss}. The temperature in Celsius should not be less than {1:F0} degrees.",
    experimentDate, experimentMinTemperature);

// Вариант с интерполяцией строк (предпочтительный)
Console.WriteLine($"The experiment will take place on {experimentDate:yyyy-MM-dd} at {experimentDate:HH:mm:ss}. The temperature in Celsius should not be less than {experimentMinTemperature:F0} degrees.");


Console.WriteLine("\n-----------------Using different string output options-----------------");

/*****************************************************************************************************************************************************************
    6. Пользователь попытался зайти на страницу, для которой у него не хватает прав. Вы хотите вывести ему информацию в виде,
       который представлен ниже. Используйте переменные из первого задания для подстановки. Предложите несколько вариантов.

       Error 403: Unauthorized

       Unfortunately, you don't have enough permissions to access the page "Finance". If you think this is wrong, please, contact us using the information below.

       Email: john.doe@example.com
       Phone: +1-800-123-4567
       Address: 1234 Maple Street, Anytown, CA 90210

******************************************************************************************************************************************************************/

Console.WriteLine("\n-----------------Using general string-----------------");

// Вариант 1 (наименее предпочтительный): использовать обычную строку и escape-последовательности для экранирования кавычек и вставки разрыва строки
string contactUs = $"{error403}\n\nUnfortunately, you don't have enough permissions to access the page \"Finance\". If you think this is wrong, please, contact us using the information below.\n\nEmail: {email}\nPhone: {phone}\nAddress: {address}";
Console.WriteLine(contactUs);


Console.WriteLine("\n-----------------Using verbatim string-----------------");

// Вариант 2 (чуть получше): использовать синтаксис "буквальной" строки
contactUs = $@"{error403}

Unfortunately, you don't have enough permissions to access the page ""Finance"". If you think this is wrong, please, contact us using the information below.

Email: {email}
Phone: {phone}
Address: {address}";

Console.WriteLine(contactUs);


Console.WriteLine("\n-----------------Using Raw String Literal-----------------");

// Вариант 3 (предпочтительный): использовать "Raw String Literal"
contactUs =
    $"""
    {error403}

    Unfortunately, you don't have enough permissions to access the page "Finance". If you think this is wrong, please, contact us using the information below.

    Email: {email}
    Phone: {phone}
    Address: {address}
    """;

Console.WriteLine(contactUs);


Console.WriteLine("\n-----------------String immutability (1)-----------------");

/*****************************************************************************************
    7. Вам дана строка. Вы пытаетесь привести её к верхнему регистру, но, почему-то,
       при выводе в консоль она всё также отображается в нижнем регистре.
       В чём причина? Исправьте код.
*****************************************************************************************/

/*
    Дело в том, что строки неизменяемы. При вызове "name.ToUpper()" создалась новая строка в верхнем регистре,
    но мы её никуда не присвоили, поэтому она так и осталась "висеть" мусором в памяти. Исходная же строка
    не изменилась, поэтому мы всё так же видим имя в нижнем регистре в консоли. Для исправления нам нужно
    присвоить результат вызова метода "ToUpper" какой-либо переменной, можно даже той же самой.
*/

string name = "john";
name = name.ToUpper();
Console.WriteLine(name);


Console.WriteLine("\n-----------------String immutability (2)-----------------");

/*********************************************************************************************************
    8. Вы имеете массив строк. Вам нужно собрать строку, которая будет содержать только нечётные
       элементы данного массива, склеенные через ", ". То есть, для приведённого ниже массива
       результирующая строка должна выглядеть следующим образом:

       "one, three, five, seven"
       
       Одно из возможных решений приведено ниже. Представьте, что массив может состоять из гораздо
       большего количества элементов. Может ли данное решение принести проблемы? Как его можно улучшить?
*********************************************************************************************************/

/*
    Да, изначальное решение может сказаться на производительности, особенно при увеличении количества элементов массива.
    В решении использовался тип "string", поэтому внутри цикла при переприсваивании каждый раз создавалась новая строка,
    а не изменялась существующая. Это происходит из-за того, что строки неизменяемы по своей природе. Промежуточные строки
        
        "one, "
        "one, three, "
        "one, three, five, "
        "one, three, five, seven, "
        
    просто остаются "висеть" в памяти, пока до них не доберётся сборщик мусора. То есть, во-первых, мы расходуем память попусту,
    а, во-вторых, заставляем чаще запускаться сборщик мусора, так как чем больше в памяти ненужных объектов, которые требуют очистки,
    тем чаще он запускается. А это уже напрямую влияет на производительность, особенно при большом количестве элементов в массиве.

    Решение: использовать "StringBuilder" вместо "string". Он умеет изменять исходную строку, не создавая промежуточных объектов в памяти.
 */

string[] strArray = ["one", "two", "three", "four", "five", "six", "seven"];  // Представьте, что могут быть тысячи элементов

var result = new StringBuilder();
for (int i = 0; i < strArray.Length; i += 2)
{
    result.Append($"{strArray[i]}, ");
}

result.Remove(result.Length - 2, 2);  // Удаляем последнюю запятую и пробел
Console.WriteLine(result);


Console.WriteLine("\n-----------------String interning-----------------");

/****************************************************************************************
    9. Сколько строк в памяти было создано системой в коде ниже?
       Можем ли мы уменьшить данное количество, чтобы оптимальнее использовать память?
****************************************************************************************/

/*
    В памяти было создано 4 строки: "test", "tes", "t" и ещё раз "test".
    Из урока мы должны помнить, что строковые литералы интернируются компилятором по умолчанию.
    Если строковые литералы в точности совпадают, то память под них будет выделена только один раз.
    В таком случае сначала будет выделена память под литерал "test" для переменной "str1". Переменной
    "str2" присваивается такой же литерал, а значит на этот раз память выделяться не будет. Будет
    использоваться объект, уже созданный ранее. Переменной "str3" присваивается результат конкатенации
    двух строковых литералов, но компилятор умеет производить такую конкатенацию, а значит он видит
    данный литерал целиком, и это опять "test". То есть, память опять выделяться не будет.
    Далее будет выделена память под литералы "tes" и "t". В последней строке переменной "str4"
    присваивается результат конкатенации двух переменных. Такие операции компилятор уже производить
    не умеет, а значит интернировать эту строку он не сможет, даже не смотря на то, что в результате
    также будет "test". Поэтому память будет выделена повторно.
    Мы можем избежать повторного выделения памяти в последней строке, если вручную интернируем выражение
    "strPart1 + strPart2", применив метод "string.Intern".
*/

string str1 = "test";
string str2 = "test";
string str3 = "te" + "st";
string strPart1 = "tes";
string strPart2 = "t";
string str4 = string.Intern(strPart1 + strPart2);

// "True", исходя из объяснения выше. Переменные "str1" и "str2" указывают на один и тот же объект в памяти. 
Console.WriteLine(ReferenceEquals(str1, str2));

// "True", исходя из объяснения выше. Переменные "str1" и "str3" указывают на один и тот же объект в памяти. 
Console.WriteLine(ReferenceEquals(str1, str3));

// Без принудительного интернирования "False", исходя из объяснения выше. Переменные "str1" и "str4" указывают на разные объекты в памяти,
// не смотря на то, что фактически эти объекты содержат одну и ту же строку.
// Если принудительно интернировать выражение "strPart1 + strPart2", то память повторно выделяться не будет, а значит переменные "str1" и "str4"
// начнут указывать на один и тот же объект в памяти. В таком случае результат данного выражение уже будет равен "True".
Console.WriteLine(ReferenceEquals(str1, str4));


Console.WriteLine("\n-----------------Types mismatching-----------------");

/****************************************************************************************************************
    10. Вы пытаетесь проверить, является ли символ буквой или цифрой, но почему-то получаете ошибку компиляции.
        В чём причина? Раскомментируйте и исправьте код.
****************************************************************************************************************/

/*
    Метод "IsLetterOrDigit" ожидает аргумент типа "char", а у нас переменная "character" имеет тип "string",
    так как символ заключён в двойные, а не одинарные кавычки. Нужно просто сменить кавычки на одинарные.
*/

var character = 'H';
Console.WriteLine(char.IsLetterOrDigit(character));
