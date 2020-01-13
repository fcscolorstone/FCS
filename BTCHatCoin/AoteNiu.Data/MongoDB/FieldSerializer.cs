using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Nethereum.Util;
using System;

namespace AoteNiu.Data
{
    [BsonSerializer(typeof(MoneyFieldSerializer))]
    public class MoneyFieldSerializer : IBsonSerializer
    {
        public Type ValueType => typeof(decimal);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var dbData = context.Reader.ReadInt32();
            return (decimal)dbData / (decimal)100;
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            var realValue = (decimal)value;
            context.Writer.WriteInt32(Convert.ToInt32(realValue * 100));
        }
    }

    [BsonSerializer(typeof(BigDecimalSerializer))]
    public class BigDecimalSerializer : IBsonSerializer
    {
        public Type ValueType => typeof(BigDecimal);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var dbData = context.Reader.ReadString();
            return BigDecimal.Parse(dbData);
        }
        
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            var realValue = (BigDecimal)value;
            context.Writer.WriteString(realValue.ToString());
        }
    }

    /// <summary>
    /// 修改操作前后值：
    /// </summary>
    public class UpdatedFiled
    {
        public BsonValue _before { get; set; }

        public BsonValue _after { get; set; }

        public UpdatedFiled(BsonValue before, BsonValue after)
        {
            _before = before;
            _after = after;
        }
    }
}
