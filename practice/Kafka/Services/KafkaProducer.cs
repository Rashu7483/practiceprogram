//using Confluent.Kafka;
//using Serilog;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//namespace practice.Kafka.Services
//{
//    public class KafkaProducer
//    {
//        private readonly string _bootstrapServers;
//        private readonly string _topic;

//        public KafkaProducer(IConfiguration configuration)
//        {
//            _bootstrapServers = configuration["Kafka:BootstrapServers"];
//            _topic = configuration["Kafka:Topic"];
//        }

//        public async Task ProduceMessageAsync(string message)
//        {
//            var config = new ProducerConfig { BootstrapServers = _bootstrapServers };
//            using var producer = new ProducerBuilder<Null, string>(config).Build();

//            var result = await producer.ProduceAsync(_topic, new Message<Null, string>
//            {
//                Value = message,
//                Timestamp = new Timestamp(DateTime.UtcNow)
//            });

//            Log.Information("Produced message to {Topic} | Partition: {Partition} | Offset: {Offset} | Time: {Timestamp}",
//                _topic, result.Partition, result.Offset, result.Timestamp.UtcDateTime);
//        }

//        public async Task ProduceFromFileAsync(string filePath)
//        {
//            var message = await File.ReadAllTextAsync(filePath);
//            await ProduceMessageAsync(message);
//        }
//    }
//}
