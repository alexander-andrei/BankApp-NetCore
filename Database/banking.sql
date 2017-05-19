-- MySQL dump 10.13  Distrib 5.6.33, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: banking
-- ------------------------------------------------------
-- Server version	5.6.33-0ubuntu0.14.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ActiveBanks`
--

DROP TABLE IF EXISTS `ActiveBanks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ActiveBanks` (
  `Id` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `ApiEntryPoint` varchar(45) NOT NULL,
  `Info` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`),
  UNIQUE KEY `ApiEntryPoint_UNIQUE` (`ApiEntryPoint`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ActiveBanks`
--

LOCK TABLES `ActiveBanks` WRITE;
/*!40000 ALTER TABLE `ActiveBanks` DISABLE KEYS */;
INSERT INTO `ActiveBanks` VALUES (1,'Raifaisen','htttp://somesite.com','No info needed !');
/*!40000 ALTER TABLE `ActiveBanks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Beneficiaries`
--

DROP TABLE IF EXISTS `Beneficiaries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Beneficiaries` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Surname` varchar(45) NOT NULL,
  `Account` varchar(45) NOT NULL,
  `BankId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Account_UNIQUE` (`Account`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Beneficiaries`
--

LOCK TABLES `Beneficiaries` WRITE;
/*!40000 ALTER TABLE `Beneficiaries` DISABLE KEYS */;
INSERT INTO `Beneficiaries` VALUES (1,'mike','test','1111111111111',1),(2,'john','cena','22222222',1);
/*!40000 ALTER TABLE `Beneficiaries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CreditCards`
--

DROP TABLE IF EXISTS `CreditCards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CreditCards` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `PinNumber` varchar(7) NOT NULL,
  `CardNumber` varchar(45) NOT NULL,
  `Ccavf` varchar(7) NOT NULL,
  `Security3d` int(11) NOT NULL,
  `Type` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `idCreditCard_UNIQUE` (`Id`),
  UNIQUE KEY `CardNumber_UNIQUE` (`CardNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CreditCards`
--

LOCK TABLES `CreditCards` WRITE;
/*!40000 ALTER TABLE `CreditCards` DISABLE KEYS */;
INSERT INTO `CreditCards` VALUES (1,1,'4321','4111111111111111','123',1,'VISA'),(2,1,'2351','5105105105105100','444',1,'MasterCard');
/*!40000 ALTER TABLE `CreditCards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Payments`
--

DROP TABLE IF EXISTS `Payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Payments` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `CreditCardId` int(11) NOT NULL,
  `TransferedValue` double NOT NULL,
  `BeneficiaryId` int(11) NOT NULL,
  `Information` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Payments`
--

LOCK TABLES `Payments` WRITE;
/*!40000 ALTER TABLE `Payments` DISABLE KEYS */;
INSERT INTO `Payments` VALUES (1,1,1,5000,1,'payed for money');
/*!40000 ALTER TABLE `Payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Transactions`
--

DROP TABLE IF EXISTS `Transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Transactions` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `Information` varchar(45) NOT NULL,
  `ActiveBankId` int(11) NOT NULL,
  `BeneficiaryId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `TransferedValue` double NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Transactions`
--

LOCK TABLES `Transactions` WRITE;
/*!40000 ALTER TABLE `Transactions` DISABLE KEYS */;
INSERT INTO `Transactions` VALUES (4,'some info that does not exist',1,0,1,12),(5,'some info that does not exist',1,0,1,5.77);
/*!40000 ALTER TABLE `Transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Surname` varchar(45) NOT NULL,
  `Account` varchar(45) NOT NULL,
  `Ballance` double NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Account_UNIQUE` (`Account`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (1,'John','Cena','123123124124',740),(2,'Mike','Scott','223123124124',22),(3,'Burns','Travis','12312312444',1244214);
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-19 17:46:38
