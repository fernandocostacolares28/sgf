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
-- Table structure for table `produto_lote`
--

DROP TABLE IF EXISTS `produto_lote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produto_lote` (
  `id_produto` int NOT NULL AUTO_INCREMENT,
  `name_produto` varchar(45) NOT NULL,
  `valor_produto` float NOT NULL,
  `qtd_produto` varchar(45) NOT NULL,
  `id_lote` int DEFAULT NULL,
  PRIMARY KEY (`id_produto`),
  KEY `id_lote` (`id_lote`),
  CONSTRAINT `id_lote` FOREIGN KEY (`id_lote`) REFERENCES `lote` (`id_lote`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produto_lote`
--

LOCK TABLES `produto_lote` WRITE;
/*!40000 ALTER TABLE `produto_lote` DISABLE KEYS */;
INSERT INTO `produto_lote` VALUES (24,'Deller 50 mg',37.55,'4',12),(25,'Lamotrigina 50 mg',35.22,'101',12),(26,'Atentah 40 mg',113.3,'100',12),(28,'Deller 50 mg',37.55,'95',14),(29,'Lamotrigina 50 mg',35.22,'100',14),(30,'Atentah 40 mg',113.3,'99',14),(31,'Dipirona 1 g',12.34,'98',14),(32,'Ritalina',11.33,'100',14),(33,'Dipirona 500 mg',6.23,'100',14);
/*!40000 ALTER TABLE `produto_lote` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-11 14:09:29
