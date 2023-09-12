using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using System;
using IntegerType = Microsoft.Spark.Sql.Types.IntegerType;
using StringType = Microsoft.Spark.Sql.Types.StringType;

namespace Library_Terekhov;

public class DataFreim
{
    public void Data()
    {
        // Создаем Spark сессию
        var spark = SparkSession.Builder()
            .AppName("ProductCategoryPairs")
            .GetOrCreate();

        // Создаем датафрейм с информацией о продуктах
        var productsSchema = new StructType(new[]
        {
            new StructField("product_id", new IntegerType(), false),
            new StructField("product_name", new StringType(), false),
            new StructField("category_id", new IntegerType(), true)
        });

        var productsData = new object[]
        {
            new object[] { 1, "Product A", 2 },
            new object[] { 2, "Product B", null },
            new object[] { 3, "Product C", 1 }
        };

        var productsDF = spark.CreateDataFrame((IEnumerable<GenericRow>)productsData, productsSchema);
        
        var categoriesSchema = new StructType(new[]
        {
            new StructField("category_id", new IntegerType(), false),
            new StructField("category_name", new StringType(), false)
        });

        var categoriesData = new object[]
        {
            new object[] { 1, "Category X" },
            new object[] { 2, "Category Y" }
        };

        var categoriesDF = spark.CreateDataFrame((IEnumerable<GenericRow>)categoriesData, categoriesSchema);
        var resultDF = productsDF
            .Join(categoriesDF, productsDF["category_id"] == categoriesDF["category_id"], "left")
            .Select(
                productsDF["product_name"],
                Functions.Coalesce(categoriesDF["category_name"], productsDF["product_name"]).Alias("category_name")
            );
        
        resultDF.Show();
        spark.Stop();
    }
}