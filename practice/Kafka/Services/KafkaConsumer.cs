//using Confluent.Kafka;
//using Serilog;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Threading;

//namespace practice.Kafka.Services
//{
//    public class KafkaConsumer
//    {
//        private readonly string _bootstrapServers;
//        private readonly string _topic;
//        private readonly string _groupId;

//        public KafkaConsumer(IConfiguration configuration)
//        {
//            _bootstrapServers = configuration["Kafka:BootstrapServers"];
//            _topic = configuration["Kafka:Topic"];
//            _groupId = configuration["Kafka:GroupId"];
//        }

//        public void StartConsumer(CancellationToken token)
//        {
//            var config = new ConsumerConfig
//            {
//                BootstrapServers = _bootstrapServers,
//                GroupId = _groupId,
//                AutoOffsetReset = AutoOffsetReset.Earliest,
//                //Earliest:Start consuming from the very beginning of the topic (all existing messages).
//                //latest:Start consuming only new messages produced after the consumer starts.
//                EnableAutoCommit = true
//                //true:Kafka automatically commits offsets periodically
//                //You must manually commit offsets in your code (consumer.Commit())
//            };

//            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
//            consumer.Subscribe(_topic);

//            try
//            {
//                while (!token.IsCancellationRequested)
//                {
//                    var cr = consumer.Consume(token);
//                    Log.Information("Consumed message: {Message} | Partition: {Partition} | Offset: {Offset} | Time: {Timestamp}",
//                        cr.Message.Value, cr.Partition, cr.Offset, cr.Message.Timestamp.UtcDateTime);
//                }
//            }
//            catch (OperationCanceledException)
//            {
//                Log.Information("Consumer stopped.");
//            }
//            finally
//            {
//                consumer.Close();
//            }
//        }
//    }
//}
