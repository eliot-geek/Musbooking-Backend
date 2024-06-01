namespace OrderService.Domain.Primitives;

public static class ExceptionMessages
{
    public const string IsLettersFormatException =
        "Строка {0} не должна содержать цифр и специальных символов. Название параметра: {1}";
    public const string StrOutOfRangeException = "Строка {0} выходит за рамки допустимой длины. Название параметра: {1}";
    public const string GuidEmptyException = "Идентификатор пользователя не может быть пустым. Название параметра: {0}";
    public const string EquipmentNotFoundException = "Оборудование с таким Id не найден в списке. Название параметра {0}";
    public const string OrderNotFound = "Заказ с таким Id не найден. Название параметра {0}";
    public const string InvalidPrice = "Цена не может быть меньше 0. Название параметра {0}";
}