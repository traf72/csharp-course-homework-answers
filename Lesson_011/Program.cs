﻿/**********************************************************************
    1. Объясните, почему строки ниже не компилируются. Исправьте код.
**********************************************************************/

short x = 100;
short y = 50;
var z = 5792342154;

// Операнды подтягиваются до типа "int", соответственно результат тоже будет типа "int". Необходимо использовать явное приведение к типу "short".
short res1 = (short)(x | y);

// Побитовые операторы могут применяться только к целочисленным типам. Суффикс "m" заставляет С# интерпретировать второй операнд как "decimal".
// "decimal" не относится к целочисленным типам, поэтому возникает ошибка компиляции. Так как число у нас все равно фактически целоe,
// мы просто можем убрать суффикс "m".
var res2 = x ^ 60;

// Операнды подтягиваются до типа "long", так как один из операндов имеет тип "long". Соответственно результат тоже будет типа "long".
// Необходимо использовать явное приведение к типу "int".
int res3 = (int)(x & z);

// Побитовые операторы могут применяться только к целочисленным типам. Дробные числа по умолчанию интерпретируются С# как "double",
// а значит второй операнд будет типа "double", поэтому возникает ошибка компиляции. Так как число у нас все равно фактически целоe,
// мы просто можем опустить дробную часть.
var res4 = x << 5;


Console.WriteLine("-------------------Bitwise operations----------------------");

/******************************************************************************
    2. Объясните на побитовом уровне, почему результат операций именно такой.
******************************************************************************/

// Как помним, операнды всегда подтягиваются до типа "int", поэтому все разъяснения приведены для 32-разрядных знаковых целых чисел.

/*
    00000000000000000000000000000100  (4)
    00000000000000000000000000001000  (8)
    --------------------------------
    00000000000000000000000000000000  (0)
 */
Console.WriteLine(4 & 8);             // 0

/*
    11111111111111111111111111111010  (-6)
    11111111111111111111111111011001  (-39)
    --------------------------------
    11111111111111111111111111011000  (-40)
 */
Console.WriteLine(-6 & -39);          // -40

/*
    00000000000000000000000000111101  (61)
    00000000000000000000000001100010  (98)
    --------------------------------
    00000000000000000000000001111111  (127)
 */
Console.WriteLine(61 | 98);           // 127

/*
    00000000000000000000000001010001  (81)
    11111111111111111111111111001100  (-52)
    --------------------------------
    11111111111111111111111111011101  (-35)
 */
Console.WriteLine(81 | -52);          // -35

/*
    00000000000000000000001010100101  (677)
    --------------------------------
    11111111111111111111110101011010  (-678)
 */
Console.WriteLine(~677);              // -678

/*
    11111111111111111111111111111111  (-1)
    --------------------------------
    00000000000000000000000000000000  (0)
 */
Console.WriteLine(~-1);               // 0

/*
    00000000000000000000000000000101  (5)
    00000000000000000000000000001010  (10)
    --------------------------------
    00000000000000000000000000001111  (15)
 */
Console.WriteLine(5 ^ 10);            // 15

/*
    11111111111111111111111111111011  (-5)
    11111111111111111111111111110110  (-10)
    --------------------------------
    00000000000000000000000000001101  (13)
 */
Console.WriteLine(-5 ^ -10);          // 13

/*
    00100000000000000000000000000000  (536870912)
    --------------------------------
    01000000000000000000000000000000  (1073741824)
 */
Console.WriteLine(536870912 << 1);    // 1073741824

/*
    00100000000000000000000000000000  (536870912)
    --------------------------------
    10000000000000000000000000000000  (-2147483648)
 */
Console.WriteLine(536870912 << 2);    // -2147483648

/*
    00100000000000000000000000000000  (536870912)
    --------------------------------
    00000000000000000000000000000000  (0)

    При увеличении количества позиций сдвига результат больше меняться не будет и всегда будет оставаться 0, так как в бинарном
    представлении после сдвига на 3 бита влево у нас остались одни нули, а младший правый бит при сдвиге будет также заполняться нулём.
 */
Console.WriteLine(536870912 << 3);    // 0 (Будет ли меняться результат, если я буду увеличивать количество позиций для сдвига? Почему?)

/*
    00000000000000000000000000000101  (5)
    --------------------------------
    00000000000000000000000000000010  (2)
 */
Console.WriteLine(5 >> 1);            // 2

/*
    00000000000000000000000000000101  (5)
    --------------------------------
    00000000000000000000000000000001  (1)
 */
Console.WriteLine(5 >> 2);            // 1

/*
    00000000000000000000000000000101  (5)
    --------------------------------
    00000000000000000000000000000000  (0)

    При увеличении количества позиций сдвига результат больше меняться не будет и всегда будет оставаться 0, так как в бинарном представлении после
    сдвига на 3 бита вправо у нас остались одни нули, а старший левый бит при сдвиге будет также заполняться нулём, так как число положительное.
 */
Console.WriteLine(5 >> 3);            // 0 (Будет ли меняться результат, если я буду увеличивать количество позиций для сдвига? Почему?)

/*
    11111111111111111111111111111011  (-5)
    --------------------------------
    11111111111111111111111111111101  (-3)
 */
Console.WriteLine(-5 >> 1);           // -3

/*
    11111111111111111111111111111011  (-5)
    --------------------------------
    11111111111111111111111111111110  (-2)
 */
Console.WriteLine(-5 >> 2);           // -2

/*
    11111111111111111111111111111011  (-5)
    --------------------------------
    11111111111111111111111111111111  (-1)

    При увеличении количества позиций сдвига результат больше меняться не будет и всегда будет оставаться -1, так как в бинарном представлении после
    сдвига на 3 бита вправо у нас остались одни единицы, а старший левый бит при сдвиге будет также заполняться единицей, так как число отрицательное.
 */
Console.WriteLine(-5 >> 3);           // -1 (Будет ли меняться результат, если я буду увеличивать количество позиций для сдвига? Почему?)

/*
    11111111111111111111111111111011  (-5)
    --------------------------------
    00111111111111111111111111111110  (1073741822)

    При применении беззнакового сдвига вправо левые старшие биты всегда заполняются нулями, даже если число отрицательное. Поэтому число превращается
    в положительное и после сдвига вправо на две позиции принимает такой вид.
 */
Console.WriteLine(-5 >>> 2);          // 1073741822


Console.WriteLine("\n-------------------Bitwise flags----------------------");

/****************************************************************************************
    3. У вас есть таблица опций, которые имеет автомобиль в зависимости от комлектации.
       Выполните задания ниже по тексту.

        --------------------------------------------------------------------
        |              | Bluetooth |  Навигация  |   Люк   |  Кондиционер  |
        --------------------------------------------------------------------
        | Базовая      |     0     |      0      |    0    |       1       |
        | Стандарт     |     1     |      0      |    0    |       1       |
        | Премиум      |     1     |      1      |    1    |       1       |
        --------------------------------------------------------------------

****************************************************************************************/

// 3.1. Определите битовые флаги для опций и битовые маски для комплектаций. Напишите функцию,
//      аналогичную функции DisplayPermissions из урока, и используйте её для проверки.

const int airConditioner = 0b_0001;
const int sunroof =        0b_0010;
const int navigation =     0b_0100;
const int bluetooth =      0b_1000;

const int basic = airConditioner;
const int standard = bluetooth | airConditioner;
const int premium = bluetooth | navigation | sunroof | airConditioner;

DisplayOptions(airConditioner);
DisplayOptions(sunroof);
DisplayOptions(navigation);
DisplayOptions(bluetooth);

DisplayOptions(basic);
DisplayOptions(standard);
DisplayOptions(premium);

// Функция выглядит точно так же, как и в уроке. Единственное, теперь нам необходимо 4 бита для наших опций,
// поэтому формат будет "B4", а не "B3". Ну и она переименована, чтобы лучше отражать смысл.
void DisplayOptions(int options)
{
    Console.WriteLine(options.ToString("B4"));
}


// 3.2. Напишите функцию аналогичную функции HasAtLeastOnePermission из урока, которая будет проверять, имеет ли автомобиль хотя бы одну из переданных опций.
//      Проверьте вашу функцию на базовых комплектациях.

bool HasAtLeastOneOption(int carConfiguration, int options)
{
    return (carConfiguration & options) != 0;
}

Console.WriteLine(HasAtLeastOneOption(basic, airConditioner));
Console.WriteLine(HasAtLeastOneOption(basic, airConditioner | bluetooth));
Console.WriteLine(HasAtLeastOneOption(standard, navigation | sunroof));


// 3.3. У вас есть автомобиль, комплектация которого представлена числом 8:
//   3.3.1. Выведите в консоль, имеет ли данный автомобиль Bluetooth.
//   3.3.2. Выведите в консоль, имеет ли данный автомобиль навигацию или кондиционер.

int carConfig = 8;
Console.WriteLine(HasAtLeastOneOption(carConfig, bluetooth));
Console.WriteLine(HasAtLeastOneOption(carConfig, navigation | airConditioner));


// 3.4. Напишите функцию, которая проверяет имеет ли автомобиль все переданные опции одновременно, а не только одну из них.
//      Функция будет аналогична функции HasAtLeastOnePermission из урока, но выражение после ключевого слова "return" изменится.
//      Скелет функции уже определён ниже. Исправьте выражение после ключевого слова "return".
//      Проверьте функцию на базовых комплектациях.

// Если мы хотим проверить, что все переданные опции присутствуют, в нашей комплектации единицы должны быть на тех же местах, что и в переданных опциях.
// Так как все остальные биты в любом случае занулятся, это возможно только когда побитовое "И" даст в результате само значение опций.
bool HasAllOptions(int carConfiguration, int options)
{
    return (carConfiguration & options) == options;
}

Console.WriteLine(HasAllOptions(basic, airConditioner));
Console.WriteLine(HasAllOptions(basic, airConditioner | bluetooth));
Console.WriteLine(HasAllOptions(premium, navigation | sunroof | airConditioner));


// 3.5. У вас есть автомобиль, комплектация которого представлена числом 13:
//   3.5.1. Выведите в консоль, имеет ли данный автомобиль одновременно и Bluetooth, и кондиционер.
//   3.5.2. Выведите в консоль, имеет ли данный автомобиль одновременно и навигацию, и люк, и кондиционер.

carConfig = 13;
Console.WriteLine(HasAllOptions(carConfig, bluetooth | airConditioner));
Console.WriteLine(HasAllOptions(carConfig, navigation | sunroof | airConditioner));


// 3.6. К вам приехал автомобиль в базовой комплектации и просит добавить опции навигации и bluetooth. Напишите функцию,
//      которая добавляет переданные опции, не трогая все остальные. Если опция уже есть, то она тоже должна остаться не тронутой.
//      Добавьте опции навигации и bluetooth данному автомобилю с помощью написанной функции. Протестируйте свою функцию также на других примерах.
//      Функция будет аналогична функции DisablePermissions из урока, но выражение после ключевого слова "return" изменится.
//      Скелет функции уже определён ниже. Исправьте выражение после ключевого слова "return".

// Просто применяем побитовое "ИЛИ" между текущей комплектацией и новыми опциями.
int EnableOptions(int carConfiguration, int options)
{
    return carConfiguration | options;
}

int newCarConfig = EnableOptions(basic, navigation | bluetooth);
DisplayOptions(newCarConfig);

newCarConfig = EnableOptions(standard, navigation | sunroof | airConditioner);
DisplayOptions(newCarConfig);


// Ниже чуть более сложные задания со звёздочкой

// 3.7*. Напишите функцию, которая отключает переданные опции, если они присутствуют, и включает их, если они отсутствуют.
//       Функция будет аналогична функции DisablePermissions из урока, но выражение после ключевого слова "return" изменится.
//       Скелет функции уже определён ниже. Исправьте выражение после ключевого слова "return".

// XOR обеспечит нам необходимую логику. Если опция в комплектации была выключена, то она включится, так как 0 и 1 даст 1.
// Если же опция была изначально включена, то 1 и 1 даст 0, а значит опция отключится. Те биты комлектации, напротив которых
// в переданных опциях окажутся нули, будут не тронуты.
int ToggleOptions(int carConfiguration, int options)
{
    return carConfiguration ^ options;
}

newCarConfig = ToggleOptions(standard, navigation | sunroof | airConditioner);
DisplayOptions(newCarConfig);


// 3.8*. Напишите функцию, которая инвертиурет переданные опции. То есть, если на вход пришло 1001, то она вернёт 0110. 
//       Скелет функции уже определён ниже. Исправьте выражение после ключевого слова "return".

/*
    Казалось бы, задача проста - всё, что нам нужно, это просто применить побитовое "НЕ". Но этого недостаточно. Вы можете попробовать
    оставить только побитовое "НЕ" и посмотреть, что выведется. Дело в том, что  побитовое "НЕ" инвертирует все биты. У нас используется
    тип "int", а значит число состоит из 32 битов, хотя нам интересны только 4 младших бита. То есть, мы должны как-то отсечь (занулить)
    все биты, кроме интересущих нас 4-х младших бит. Для этого мы и делаем дополнительно побитовое "И" с 4-мя единицами. Давайте даже
    подробно посмотрим как это происходит на побитовом уровне:
    1. Например, мы передаем в качестве опций нашу комплектацию "standrad", то есть, 1001, но фактически данное число будет выглядеть как:
       00000000000000000000000000001001
    2. Далее мы применяем побитовое "НЕ", и наше число становится равным 11111111111111111111111111110110. Но это не то что нам нужно. Нас
       интересуют только 4 младших бита, и мы должны как-то занулить все остальные биты.
    3. Зануляем ненужные нам биты с помощью побитового "И":
    
       11111111111111111111111111110110
       00000000000000000000000000001111
       --------------------------------
       00000000000000000000000000000110
    
       И теперь мы получили то, что нам нужно - комбинацию 0110.
*/
int NegateOptions(int options)
{
    return ~options & 0b_1111;
}

newCarConfig = NegateOptions(standard);
DisplayOptions(newCarConfig);


Console.WriteLine("\n-------------------Packing multiple numbers into one----------------------");

/**********************************************************************************************************************************
    4*. Вы подключили стороннюю библиотеку, которая требует, чтобы дата и время передавались ей одним
        32-битным беззнаковым целым числом в формате yyyyMMddHHmm, где
          yyyy - 4 знака для года                         (12 бит)
          MM - 2 знака для месяца                         (4 бита)
          dd - 2 знака для дня                            (5 бит)
          HH - 2 знака для часов в 24-часовом формате     (5 бит)
          mm - 2 знака для минут                          (6 бит)
        
        То есть, например, дата и время 05.10.2007 22:08 должны упаковаться как 200710052208.
        
        4.1. Упакуйте дату из примера в 32-разрядное беззнаковое целое. Выведите получившееся число в консоль.
             Совпадает ли оно с числом 200710052208? Почему?
        4.2. Распакуйте обратно все компоненты даты и выведите их в консоль. Убедитесь, что они совпадают с числами до упаковки.
**********************************************************************************************************************************/

int year = 2007;
int month = 10;
int day = 5;
int hours = 22;
int minutes = 8;

// Упаковываем компоненты даты и времени в одно число

/*
    1. Если мы сложим все биты, которые занимают компоненты даты, то увидим, что у нас как раз в сумме получается 32 бита: 12 + 4 + 5 + 5 + 6 = 32.
       То есть, у нас будут заняты все биты нашего беззнакового 32-разрядного целого числа.
    2. Год у нас занимает 12 бит, а значит мы должны сдвинуть его на 20 бит влево (32 - 12 = 20).
    3. Месяц занимает 4 бита, мы должны сдвинуть его на 16 бит влево (20 - 4 = 16).
    4. День занимает 5 бит, мы должны сдвинуть его на 11 бит влево (16 - 5 = 11).
    5. Часы занимают 5 бит, мы должны сдвинуть их на 6 бит влево (11 - 5 = 6).
    6. Минуты занимают оставшиеся 6 бит, тут сдвиг нам не нужен.
    7. Ну и собираем все наши сдвинутые биты в одно число, применив побитовое "ИЛИ".
*/
uint dateTime = (uint)(year << 20 | month << 16 | day << 11 | hours << 6 | minutes);

Console.WriteLine(dateTime);                    // В десятичной системе
Console.WriteLine(dateTime.ToString("B32"));    // В двоичной системе

/*
    Конечно наше упакованное число будет отличаться от числа 200710052208, которое складывается из отдельных компонентов даты.
    Потому что биты данного числа интерпретируются как единое целое. Только логика нашей программы знает, что мы храним
    в данном числе отдельные компоненты, и какие биты за какой компонент отвечают. После компоновки в двоичном представлении
    это число выглядит следующим образом 01111101011110100010110110001000, что в десятичной системе как раз равно 2105159048.
    Если же мы разобьём это число побитово, то мы сможем увидеть компоненты нашей даты:
    011111010111 1010 00101 10110 001000
    ------------------------------------
        2007      10    5     22    8
*/

Console.WriteLine("\n-------------------Extracting date components back----------------------");

// Для минут сдвиг не нужен. Нас интересуют только младшие 6 бит, остальные биты мы должны занулить (аналогично,
// как мы делали для метода "NegateOptions", только маска тут указана в 16-ричной системе счисления).
uint extractedMinutes = dateTime & 0x3F;

// Сдвигаем на 6 бит вправо. Нас интересуют только младшие 5 бит, остальные биты мы должны занулить.
uint extractedHours = dateTime >> 6 & 0x1F;

// Сдвигаем на 11 бит вправо. Нас интересуют только младшие 5 бит, остальные биты мы должны занулить.
uint extractedDay = dateTime >> 11 & 0x1F;

// Сдвигаем на 16 бит вправо. Нас интересуют только младшие 4 бита, остальные биты мы должны занулить.
uint extractedMonth = dateTime >> 16 & 0xF;

// Сдвигаем на 20 бит вправо. Все ненужные нам биты сдвинутся вправо и отбросятся, поэтому занулять что-то явно, как в примерах выше, необязательно.
// Хотя для надёжности это также можно сделать, в таком случае нам понадобится маска из 12-и единиц, то есть, 0xFFF в 16-ричной системе.
uint extractedYear = dateTime >> 20 & 0xFFF;

Console.WriteLine(extractedYear);
Console.WriteLine(extractedMonth);
Console.WriteLine(extractedDay);
Console.WriteLine(extractedHours);
Console.WriteLine(extractedMinutes);
