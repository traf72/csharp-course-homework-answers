﻿using System.Globalization;
using System.Text;

Console.WriteLine("-----------------String members-----------------");

/***********************************************************************************************************************************
    1. Вам дана строка "A journey of a thousand miles begins with a single step." Выполните задания ниже.
       Все манипуляции проводите, не изменяя исходную строку, то есть, не переприсваивая исходную переменную.
         1.1.  Выведите в консоль её длину.
         1.2.  Выведите в консоль первый символ.
         1.3.  Выведите в консоль 16-й символ.
         1.4.  Выведите в консоль последний символ (несколькими способами).
         1.5.  Выведите в консоль пятый символ с конца (несколькими способами).
         1.6.  Найдите индекс первого вхождения слова "begins" (существует специальный метод).
               Выведите его в консоль в виде "The word "begins" found at index 30".
         1.7.  Получитие подстроку "begins with a single step." и выведите её в консоль.
               Чтобы не высчитывать стартовый индекс вручную, используйте индекс, полученный на предыдущем шаге.
         1.8.  Получитие подстроку "thousand miles" и выведите её в консоль.
         1.9.  Удалите подстроку "a thousand miles begins with", чтобы осталось только "A journey of a single step.".
               Выведите в консоль получившуюся строку "A journey of a single step.".
         1.10. В последней получившейся строке "A journey of a single step." замените "a single step" на "multiple steps".
               В итоге должно получиться "A journey of multiple steps."
         1.11. В последнюю строку вставьте слово "wonderful". В итоге должно получиться "A wonderful journey of multiple steps.".
         1.12. Проверьте, что строка начинается с подстроки "A wonderful journey".
         1.13. Отрежьте точку в конце, то есть, должно остаться только "A wonderful journey of multiple steps".
               Приведите несколько вариантов того, как это можно сделать.
         1.14. Проверьте, что строка оканчивается на подстроку "multiple steps".
         1.15. Разбейте последнюю получившуюся строку на отдельные слова.
               Должен получиться массив ["A", "wonderful", "journey", "of", "multiple", "steps"].
         1.16. Склейте обратно все слова в одну строку, но уже с разделителем "; ".
               Должна получиться строка "A; wonderful; journey; of; multiple; steps".
         1.17. Определите, содержит ли строка из пункта выше подстроку "wonderful journey".
***********************************************************************************************************************************/

string phrase = "A journey of a thousand miles begins with a single step.";

// 1.1. Длина строки содержится в свойстве "Length".
Console.WriteLine(phrase.Length);

// 1.2. Индексирование начинается с нуля, поэтому первый символ находится по индексу "0".
Console.WriteLine(phrase[0]);

// 1.3. Индексирование начинается с нуля, поэтому 16-й символ находится по индексу "15".
Console.WriteLine(phrase[15]);

// 1.4. Так как индексирование начинается с нуля, то индекс последнего символа - это длина строки минус один.  
Console.WriteLine(phrase[phrase.Length - 1]);
Console.WriteLine(phrase[^1]); // То же самое, но с использованием синтаксиса указания индекса с конца.                 

// 1.5. Аналогично предыдущему пункту, но для 5-го символа с конца.
Console.WriteLine(phrase[phrase.Length - 5]); 
Console.WriteLine(phrase[^5]);

// 1.6. Метод "IndexOf" ищет первое вхождение переданной подстроки, начиная с начала исходной строки.
//      Если подстрока найдена, то он возвращает индекс её начала, а если нет, то -1.
//      Существует также метод "LastIndexOf". Он работает аналогично, только начинает поиск с конца исходной строки.
//      В данном случае мы использовали перегрузку, которая принимает параметр "StringComparison". Если не передавать его
//      явно, то по умолчанию используется "StringComparison.CurrentCulture". В данном случае мы указываем его явно,
//      потому что должны помнить из статьи "Best practices for comparing strings in .NET", что лучше не полагаться
//      на поведение по умолчанию, а всегда явно указывать опцию сравнения строк. Плюс, мы переопределили опцию на
//      "StringComparison.Ordinal", так как в данном случае мы работаем с английским алфавитом, а для него вполне
//      достаточно "Ordinal" сравнения, тем более, что оно работает быстрее остальных. В последующих примерах для
//      методов, которые имеют перегрузки, принимающие "StringComparison", также будет использоваться опция "Ordinal".
int beginsIndex = phrase.IndexOf("begins", StringComparison.Ordinal);
Console.WriteLine("The word \"begins\" found at index " + beginsIndex);

// 1.7. Используем метод "Substring" с указанием стартового индекса слова "begins", который мы определили в предыдущем пункте.
//      Так как мы не передаём длину вторым параметром, это значит что мы хотим взять подстроку, начиная со стартового индекса
//      и до конца исходной строки, что нам и нужно в данном случае.
string substr = phrase.Substring(beginsIndex);
substr = phrase[beginsIndex..];  // То же самое, но используя оператор диапазона.
Console.WriteLine(substr);

// 1.8.
// Сначала определяем индекс вхождения слова "thousand", чтобы не высчитывать его вручную.
int thousandIndex = phrase.IndexOf("thousand", StringComparison.Ordinal);
// Используем метод "Substring" с указанием стартового индекса слова "thousand", который мы определили в предыдущем пункте,
// и длину необходимой нам подстроки, в данном случае 14.
substr = phrase.Substring(thousandIndex, 14);
Console.WriteLine(substr);

// 1.9.
// Сначала определяем индекс вхождения фразы "a thousand", чтобы не высчитывать его вручную.
thousandIndex = phrase.IndexOf("a thousand", StringComparison.Ordinal);
// Удаляем подстроку, указывая индекс начала и её длину.
substr = phrase.Remove(thousandIndex, 29);
Console.WriteLine(substr);

// 1.10. Заменяем в строке фразу "a single step" на "multiple steps" с помощью метода "Replace".
substr = substr.Replace("a single step", "multiple steps", StringComparison.Ordinal);
Console.WriteLine(substr);

// 1.11. Вставляем слово "wonderful" на нужное нам место с помощью метода "Insert". Первым параметром указываем индекс, куда
//       нужно произвести вставку. В нашем случае он равен 2. Также для верной вставки необходимо добавить пробел.
substr = substr.Insert(2, "wonderful ");
Console.WriteLine(substr);

// 1.12. Для определения, начинается ли строка на определённую подстроку, используем метод "StartsWith".
Console.WriteLine(substr.StartsWith("A wonderful journey", StringComparison.Ordinal));

// 1.13.
// Вариант 1: используя метод "Remove", удаляем последний символ, которым и являетсяа '.'.
substr = substr.Remove(substr.Length - 1);

// Вариант 2: используя метод "TrimEnd", которому в качестве символа передаём символ '.'.
substr = substr.TrimEnd('.');
Console.WriteLine(substr);

// 1.14. Для определения, оканчивается ли строка на определённую подстроку, используем метод "EndsWith".
Console.WriteLine(substr.EndsWith("multiple steps", StringComparison.Ordinal));

// 1.15. Для разбития строки на слова используем метод "Split" и разделитель ' '.
string[] words = substr.Split(' ');

// 1.16. Для склеивания слов массива обратно в строку используем метод "Join" и разделитель "; ".
string joinedBySemicolon = string.Join("; ", words);
Console.WriteLine(joinedBySemicolon);

// 1.17. Для определения содержит ли строка какую-то подстроку используется метод "Contains".
Console.WriteLine(joinedBySemicolon.Contains("wonderful journey", StringComparison.Ordinal));


Console.WriteLine("\n-----------------StringBuilder members-----------------");

/********************************************************************************************************************************************
    2. Создайте из строки из первого задания объект "StringBuilder". Все манипуляции из заданий ниже должны выполняться именно
       с изначально созданным объектом "StringBuilder". Он не должен пересоздаваться или приводиться к строке методом "ToString".
         2.1.  Выведите в консоль строку, которую он содержит.
         2.2.  Выведите в консоль длину строки, которую он содержит.
         2.3.  Выведите в консоль 25-й символ.
         2.4.  Выведите в консоль второй символ с конца (несколькими способами).
         2.5.  Измените последний символ на '!'. Выведите получившуюся строку в консоль.
         2.6.  Обрежьте строку до первых 29 символов. Предложите несколько вариантов это сделать.
               Выведите полученную строку в консоль.
         2.7.  Увеличьте строку обратно до 56 символов (только её длину). Выведите её в консоль, а также её длину.
               Почему длина равна 56, а в консоли мы всё также видим только 29 символов?
         2.8.  Восстановите исходную строку, не пересоздавая объект "StringBuilder". Предложите несколько вариантов.
         2.9.  Превратите строку "A journey of a thousand miles begins with a single step." в строку
               "A-journey-of-a-thousand-miles-begins-with-a-single-step.".
         2.10. Очистите "StringBuilder". Добавьте слова "One", "Two" и "Three", разделённые запятой. Не компонуйте необходимую
               строку вручную, чтобы добавить её целиком. Вам нужно добавить три слова через разделитель используя методы "StringBuilder".
               В результате должно получиться "One,Two,Three". Предложите несколько вариантов это сделать.
********************************************************************************************************************************************/

// Используем конструктор, принимающий в себя строку.
var strBuilder = new StringBuilder(phrase);

// 2.1. Просто передаём объект "StringBuilder" методу "WriteLine".
Console.WriteLine(strBuilder);

// 2.2. "StringBuilder" точно так же содержит свойство "Length".
Console.WriteLine(strBuilder.Length);

// 2.3. "StringBuilder" точно так же содержит индексатор для возможности обращения к отдельным символам строки.
Console.WriteLine(strBuilder[24]);

// 2.4. Аналогично, как это делалось для типа "string" выше.
Console.WriteLine(strBuilder[strBuilder.Length - 2]);
Console.WriteLine(strBuilder[^2]);

// 2.5. В отличие от типа "string", тип "StringBuilder" позволяет изменять символы, используя индексатор.
strBuilder[^1] = '!';
Console.WriteLine(strBuilder);

// 2.6.
// Вариант 1: использовать метод "Remove", чтобы удалить ненужное окончание строки.
strBuilder.Remove(29, strBuilder.Length - 29);

// Вариант 2 (предпочтительный): присвоить свойству "Length" необходимую длину.
/*
    В "StringBuilder", в отличие от "string", свойство "Length" можно изменять.
    Если значение меньше текущей длины строки, то строка будет обрезана до указанной длины.
*/
strBuilder.Length = 29;

Console.WriteLine(strBuilder);

// 2.7. Если значение больше текущей длины строки, то строка будет дополнена null-символом '\0' до указанной длины.
strBuilder.Length = 56;

// Символ '\0' не выводится при отображении, поэтому, хотя длина строки и равна 56, в консоли мы всё ещё видим только первые 29 символов.
// Символ '\0' можно увидеть в отладчике.
Console.WriteLine(strBuilder);
Console.WriteLine(strBuilder.Length);

// 2.8.
// Вариант 1: затримить строку обратно до 29 символов, чтобы отсечь null-символы, и добавить необходимый остаток строки.
strBuilder.Length = 29;
strBuilder.Append(phrase[29..]);
Console.WriteLine(strBuilder);

// Вариант 2 (более простой): очистить "StringBuilder", а затем добавить исходную строку обратно.
strBuilder.Clear();
strBuilder.Append(phrase);

// Или можно даже в одну строку, так как метод "Clear" возвращает обратно объект "StringBuilder".
strBuilder.Clear().Append(phrase);

Console.WriteLine(strBuilder);

// 2.9.
// Просто заменяем пробелы на дефис.
strBuilder.Replace(' ', '-');
Console.WriteLine(strBuilder);

// 2.10.
// Вариант 1: просто используем метод "Append" нужное количество раз.
strBuilder
    .Clear()
    .Append("One")
    .Append(',')
    .Append("Two")
    .Append(',')
    .Append("Three");
Console.WriteLine(strBuilder);

// Вариант 2 (более предпочтительный): использовать метод "AppenJoin".
strBuilder
    .Clear()
    .AppendJoin(',', "One", "Two", "Three");
Console.WriteLine(strBuilder);


Console.WriteLine("\n-----------------IndexOutOfRangeException-----------------");

/**********************************************************************************************
    3. Для строки ниже я пытаюсь получить последний символ '!', но почему-то получаю ошибку.
       В чём причина? Исправьте код.
**********************************************************************************************/

/*
    Индекс последнего символа определён неверно. Индексирование начинается с нуля, а значит индекс последнего символа будет не 10, а 9.
    Но лучше использовать специальный синтаксис указания индекса с конца.
*/

string greeting = "Hi, there!";
Console.WriteLine(greeting[9]);   // Индекс символа '!' равен 9.
Console.WriteLine(greeting[^1]);  // Предпочтительный синтаксис обращения к последнему элементу.


Console.WriteLine("\n-----------------Trim methods-----------------");

/*********************************************************************************************************
    4. Вам дана строка. Выполните задания ниже. Все манипуляции проводите, не изменяя исходную строку.
         4.1. Обрежьте пробельные символы только в начале и выведите в консоль.
         4.2. Обрежьте пробельные символы только в конце и выведите в консоль.
         4.3. Обрежьте пробельные символы с обоих сторон и выведите в консоль.
         4.4. Обрежьте с обоих сторон не только пробельные символы, но и символы '$' и '*'.
*********************************************************************************************************/

string str = "\t  **$$ Stay curious, stay inspired!! $$**  \n";

// 4.1. Используем метод "TrimStart" без параметров.
Console.WriteLine(str.TrimStart());

// 4.2. Используем метод "TrimEnd" без параметров.
Console.WriteLine(str.TrimEnd());

// 4.3. Используем метод "Trim" без параметров.
Console.WriteLine(str.Trim());

// 4.4. Используем метод "Trim", куда передаём необходимые символы в качестве параметров через запятую.
//      Заметьте, что если мы откатываемся до версии "Trim" с параметрами, то нам необходимо передавать
//      все необходимые символы вручную, включая разного рода пробельные символы.
Console.WriteLine(str.Trim(' ', '\t', '\n', '$', '*'));


Console.WriteLine("\n-----------------Split method-----------------");

/*******************************************************************************************************************
    5. Я разбиваю входящую строку на подстроки по разделителю ";". Далее я вывожу полученные части в консоль.
       Но в консоли для некоторых строк я почему-то вижу ведущий пробел, хотя он мне не нужен.
       Предложите варианты, как можно избавиться от данного ведущего пробела, если:
         5.1. Формат входящей строки гарантирует, что разделитель всегда, помимо точки с запятой,
              будет содержать ещё и пробел, то есть, возможен только единственный вариант "; ".
         5.2. Формат входящей строки гарантирует, что разделитель всегда будет содержать ";", но он может
              быть как с пробелом, так и без, то есть, возможны варианты ";" и "; ". Например, строка может
              выглядеть как "One; Two;Three".
         5.3. Аналогично пункту 5.2, но также ещё могут встречаться пустые вхождения, которые вам нужно отсекать.
              То есть, входящая строка может выглядеть как "One; Two;Three; ;Four;;Five;Six".

       Для примера входящая строка состоит только из трёх частей, но давайте предположим, что в реальности она
       может содержать сотни частей.
*******************************************************************************************************************/

Console.WriteLine("\n-----------------Split method (5.1)-----------------");

// 5.1. Если есть гарантия, что разделитель всегда будет в неизменном виде, то самый простой способ это сделать,
//      это указать разделитель именно в том виде, в котором мы его ожидаем, то есть, "; ". Метод "Split" имеет
//      перегрузку, которая в качестве разделителя может принимать строку.
{
    string inputString = "One; Two; Three";
    string[] parts = inputString.Split("; "); // Меняем ';' на "; "
    DisplayStringParts(parts);
}

Console.WriteLine("\n-----------------Split method (5.2)-----------------");

// 5.2. Если гарантии по разделителю нет, то мы уже не можем применить метод выше, так как рискуем получить неверный
//      результат разбивки. Но такая ситуация встречается на практике довольно часто, поэтому разработчики Microsoft
//      уже всё предусмотрели за нас. Метод "Split" имеет перегрузку, которая может принимать параметр "StringSplitOptions".
//      Это перечисление с тремя значениями. Одно из значений - это "TrimEntries", что как раз означает: "Отсечь пробельные
//      символы в полученных подстроках".
//      Этот вариант будет также хорошо работать и в первом случае. Поэтому, если вы не уверены в разделителе, то лучше
//      предпочесть данный вариант.
{
    string inputString = "One; Two;Three";
    string[] parts = inputString.Split(';', StringSplitOptions.TrimEntries);  // Используем "StringSplitOptions.TrimEntries"
    DisplayStringParts(parts);
}

Console.WriteLine("\n-----------------Split method (5.3)-----------------");

// 5.3. Если у нас также могут встречаться пустые вхождения, что на практике тоже не редкость, то в перечислении "StringSplitOptions"
//      существует ещё один вариант именно для данного кейса. Он называется "RemoveEmptyEntries". Но, если мы применим только данный
//      флаг, то избавимся только от пустых вхождений, но у нас останется проблема выше с отсечением пробелов. То есть, нам нужно
//      каким-то образом применить два флага сразу - и "TrimEntries", и "RemoveEmptyEntries". И это, на самом деле, возможно. На 11-ом
//      уроке мы рассматривали битовые флаги. Вот это ни что иное, как их применение. Мы там использовали константы, но я упоминал,
//      что в C# для этих целей существует и специальный вид перечислений. Мы их ещё коснёмся в будущем, но логика тут точно такая же.
//      Элементы перечислений - это и есть наши константы, и мы можем их комбинировать в битовые маски всё тем же оператором "Побитовое ИЛИ".
{
    string inputString = "One; Two;Three; ;Four;;Five;Six";
    // Применяем оба флага сразу, используя оператор "Побитовое ИЛИ".
    string[] parts = inputString.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    DisplayStringParts(parts);
}

// Вспомогательный метод для вывода частей строки в консоль. Его трогать не нужно.
static void DisplayStringParts(string[] parts)
{
    foreach (string part in parts)
    {
        Console.WriteLine($"\"{part}\"");
    }
}


Console.WriteLine("\n-----------------Checking for null, empty or white space-----------------");

/***********************************************************************************************************************************
    6. Проверка строк на пустоту.
         6.1. Объявите пустую строку несколькими способами.
         6.2. Объявите строковую переменную, содержащую значение "null".
         6.3. Объявите строковую переменную, содержащую только пробельные символы различного характера.
         6.4. Проверьте все выше созданные строки на пустую строку.
         6.5. Проверьте все выше созданные строки на пустую строку или "null".
         6.6. Проверьте все выше созданные строки на пустую строку, "null" или строку, состоящую только из пробельных символов.
***********************************************************************************************************************************/

// 6.1.
string emptyStr = string.Empty;
string emptyStr2 = "";

// 6.2.
string nullStr = null;

// 6.3.
string whiteSpaceStr = "\t  \n ";


Console.WriteLine("\n-----------------Only empty-----------------");

// 6.4. Это можно сделать несколькими способами:
Console.WriteLine(emptyStr.Length == 0);
Console.WriteLine(nullStr == string.Empty);
//Console.WriteLine(nullStr.Length == 0);    // Выдаст ошибку "NullReferenceException". Раскомментируйте, чтобы попробовать.
Console.WriteLine(whiteSpaceStr == "");


Console.WriteLine("\n-----------------Null or empty-----------------");

// 6.5.
Console.WriteLine(string.IsNullOrEmpty(emptyStr));
Console.WriteLine(string.IsNullOrEmpty(nullStr));
Console.WriteLine(string.IsNullOrEmpty(whiteSpaceStr));


Console.WriteLine("\n-----------------Null or white space-----------------");

// 6.6.
Console.WriteLine(string.IsNullOrWhiteSpace(emptyStr));
Console.WriteLine(string.IsNullOrWhiteSpace(nullStr));
Console.WriteLine(string.IsNullOrWhiteSpace(whiteSpaceStr));


Console.WriteLine("\n-----------------ToString-----------------");

/***********************************************************************************************************************************
    7. Вы написали функцию, которая проверяет, содержит ли переданная строка символ '.'. Вы пытаетесь передать в неё различные
       данные, включая строки, числа, символы и даже объект "StringBuilder". Но некоторые строки кода не компилируются.
       Раскомментируйте их и предложите вариант исправления.
***********************************************************************************************************************************/


// Всё что нужно сделать, это привести типы к строке с помощью метода "ToString":

Console.WriteLine(ContainsDot("I love .NET"));
Console.WriteLine(ContainsDot(new StringBuilder("Hi there!").ToString()));
Console.WriteLine(ContainsDot(5.78.ToString()));
Console.WriteLine(ContainsDot('.'.ToString()));


static bool ContainsDot(string str)
{
    return str.Contains('.', StringComparison.Ordinal);
}


Console.WriteLine("\n-----------------ToString (numbers formatting)-----------------");

/*******************************************************************************************************
    8. Выведите число PI с 7-ю знаками после запятой в текущей культуре и в культуре Британии (en-GB).
*******************************************************************************************************/

// Для текущей культуры
Console.WriteLine(double.Pi.ToString("F7"));

// или используя интерполяцию строк
Console.WriteLine($"{double.Pi:F7}");

// Для культуры Британии
Console.WriteLine(double.Pi.ToString("F7", CultureInfo.GetCultureInfo("en-GB")));


Console.WriteLine("\n-----------------ToString (dates formatting)-----------------");

/*********************************************************************************************************************
    9. Создайте дату 2024-12-07 и выведите её в текущей культуре, культуре США (en-US) и культуре Китая (zh-CN).
*********************************************************************************************************************/

// Можно
//var date = new DateTime(2024, 12, 7);

// Но в .NET 6 появился тип "DateOnly", который является более предпочтительным для представления только даты без времени, что как раз необходимо в нашем случае.
var date = new DateOnly(2024, 12, 7);

// Для текущей культуры
Console.WriteLine(date);

// Для культуры США
Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-US")));

// Для культуры Китая
Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("zh-CN")));
