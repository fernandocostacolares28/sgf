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
-- Table structure for table `pagamentos_contapagar`
--

DROP TABLE IF EXISTS `pagamentos_contapagar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagamentos_contapagar` (
  `id_pagamento` int NOT NULL AUTO_INCREMENT,
  `id_contapagar` int NOT NULL,
  `data_pagamento` datetime(6) NOT NULL,
  `valorparcela_pagamento` float NOT NULL,
  `status_pagamento` varchar(45) NOT NULL,
  PRIMARY KEY (`id_pagamento`),
  KEY `fk_id_contapagar_idx` (`id_contapagar`),
  CONSTRAINT `fk_id_contapagar` FOREIGN KEY (`id_contapagar`) REFERENCES `contapagar` (`id_contapagar`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamentos_contapagar`
--

LOCK TABLES `pagamentos_contapagar` WRITE;
/*!40000 ALTER TABLE `pagamentos_contapagar` DISABLE KEYS */;
INSERT INTO `pagamentos_contapagar` VALUES (1,8,'2024-10-10 16:32:45.521525',500,'pago'),(2,9,'2024-10-10 16:52:13.692016',1000.04,'pago'),(3,9,'2024-10-10 16:54:10.125233',1000.04,'pago'),(4,10,'2024-10-10 16:58:52.565787',1000,'pago'),(5,10,'2024-10-10 16:58:55.639167',1000,'pago'),(6,10,'2024-10-10 16:58:58.117238',1000,'pago'),(7,10,'2024-10-10 16:59:00.703236',1000,'pago'),(8,11,'2024-10-11 14:51:41.835862',1000.1,'pago');
/*!40000 ALTER TABLE `pagamentos_contapagar` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-14 11:51:39
