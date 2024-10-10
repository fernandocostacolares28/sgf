-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: sgfdb
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `pagamentos_contareceber`
--

DROP TABLE IF EXISTS `pagamentos_contareceber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagamentos_contareceber` (
  `id_pagamento` int NOT NULL AUTO_INCREMENT,
  `id_contareceber` int NOT NULL,
  `data_pagamento` datetime(6) NOT NULL,
  `valorparcela_pagamento` float NOT NULL,
  `status_pagamento` varchar(255) NOT NULL,
  PRIMARY KEY (`id_pagamento`),
  KEY `fk_contareceber` (`id_contareceber`),
  CONSTRAINT `fk_contareceber` FOREIGN KEY (`id_contareceber`) REFERENCES `contareceber` (`id_contareceber`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamentos_contareceber`
--

LOCK TABLES `pagamentos_contareceber` WRITE;
/*!40000 ALTER TABLE `pagamentos_contareceber` DISABLE KEYS */;
INSERT INTO `pagamentos_contareceber` VALUES (1,3,'2024-10-09 16:54:37.891030',37.1733,'pago'),(2,3,'2024-10-09 17:14:07.622891',37.1733,'pago'),(3,3,'2024-10-09 17:14:17.111211',37.1733,'pago'),(4,4,'2024-10-10 16:51:54.007622',12.3475,'pago'),(5,4,'2024-10-10 16:55:15.109358',12.3475,'pago'),(6,4,'2024-10-10 16:55:17.682354',12.3475,'pago'),(7,5,'2024-10-10 16:59:49.036304',23.305,'pago'),(8,5,'2024-10-10 16:59:52.393443',23.305,'pago'),(9,5,'2024-10-10 16:59:54.919371',23.305,'pago'),(10,5,'2024-10-10 16:59:57.886603',23.305,'pago');
/*!40000 ALTER TABLE `pagamentos_contareceber` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-10 17:09:58
