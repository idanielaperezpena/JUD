using Entidades;
using Entidades.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ExtensionsUtility
{
    public static T ParseTo<T>(this object input, string stringFormat = null)
    {
        try
        {
            if (input == null || string.IsNullOrWhiteSpace(input.ToString()))
                return default(T);

            if (typeof(T).IsEnum)
                return (T)Enum.Parse(typeof(T), input.ToString().Trim());

            if (typeof(T) == typeof(string) && (input.GetType() == typeof(DateTime) || input.GetType() == typeof(DateTime?)))
                return (T)(object)DateTime.Parse(input.ToString().Trim()).ToString(stringFormat ?? "dd/MM/yyyy");

            if ((typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?)) && !string.IsNullOrWhiteSpace(stringFormat))
                return (T)(object)DateTime.ParseExact(input.ToString().Trim(), stringFormat, null);

            if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                return ParseBool<T>(input.ToString().Trim());

            if (typeof(T) == typeof(int) && (input.GetType() == typeof(bool) || input.GetType() == typeof(bool?)))
                return (T)(object)(ParseBool<bool>(input.ToString()) ? 1 : 0);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
            return (T)tc.ConvertFrom(input.ToString().Trim());
        }
        catch (Exception)
        {
            return default(T);
        }
    }

    public static T ParseTo<T>(this object input, NumberStyles style)
    {
        try
        {
            if (input == null || string.IsNullOrWhiteSpace(input.ToString()))
                return default(T);

            var _input = input.ToString();

            if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                return (T)(object)int.Parse(_input.Trim(), style);

            if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
                return (T)(object)short.Parse(_input.Trim(), style);

            if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                return (T)(object)long.Parse(_input.Trim(), style);

            if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                return (T)(object)double.Parse(_input.Trim(), style);

            if (typeof(T) == typeof(float) || typeof(T) == typeof(float?))
                return (T)(object)float.Parse(_input.Trim(), style);

            if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
                return (T)(object)decimal.Parse(_input.Trim(), style);

            return default(T);
        }
        catch (Exception)
        {
            return default(T);
        }
    }

    private static T ParseBool<T>(string input)
    {
        if (input == "1" || input.ToString().ToLower() == "true")
            return (T)(object)true;

        return (T)(object)false;
    }

    public static string ToBase64(this string input, bool isUrlSafe = false)
    {
        var codedInput = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

        if (isUrlSafe)
            return codedInput.Replace("/", "_").Replace("+", "-");

        return codedInput;
    }

    public static string FromBase64(this string input, bool isUrlSafe = false)
    {
        if (isUrlSafe)
            input = input.Replace("_", "/").Replace("-", "+");

        var decodedInput = Encoding.UTF8.GetString(Convert.FromBase64String(input));

        return decodedInput;
    }

    public static T FromJSON<T>(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return default(T);

        return JsonConvert.DeserializeObject<T>(input);
    }

    public static string ToJSON(this object input)
    {
        return JsonConvert.SerializeObject(input);
    }

    public static string JoinElements<T>(this IEnumerable<T> elements, string separador = "|")
    {
        return string.Join(separador, elements);
    }

    public static string ToDescription(this Enum enumType, int atributoIndex = 0)
    {
        var info = enumType.GetType().GetField(enumType.ToString());
        var attributes = info.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && atributoIndex < attributes.Length && atributoIndex >= 0)
            return attributes[atributoIndex].Description;
        else
            return enumType.ToString();
    }

    public static CustomPager<T> PaginarListado<T>(this IEnumerable<T> listado, int paginaActual, int itemsPorPagina, int itemsParaCaption)
    {
        if (listado == null)
            listado = Enumerable.Empty<T>();

        return new CustomPager<T>(listado, paginaActual, itemsPorPagina, itemsParaCaption);
    }

    public static void PaginarListado<T>(this PagedViewModel<T> pagedModel, IEnumerable<T> listado)
    {
        pagedModel.ddlSelectedPage += pagedModel.btnPage.ParseTo<int>();
        pagedModel.Listado = listado.PaginarListado(pagedModel.ddlSelectedPage, pagedModel.ItemsPerPage, pagedModel.ItemsForCaption);
    }

    public static CustomSelectList<T> SelectListado<T>(this IEnumerable<T> listado) where T : ICustomSelectList
    {
        if (listado == null)
            listado = Enumerable.Empty<T>();

        return new CustomSelectList<T>(listado);
    }
}