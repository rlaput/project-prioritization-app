/*
SQLyog Community v12.12 (64 bit)
MySQL - 5.6.27-log : Database - ppa
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`ppa` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `ppa`;

/*Table structure for table `criterion` */

DROP TABLE IF EXISTS `criterion`;

CREATE TABLE `criterion` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CriterionName` varchar(255) NOT NULL,
  `Weight` float NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `criterion` */

insert  into `criterion`(`Id`,`CriterionName`,`Weight`) values (1,'Difficulty',0.1),(2,'Impact to Business',0.25),(3,'Related to CSO Goals',0.25),(4,'Number of Users',0.15),(5,'Urgency',0.25);

/*Table structure for table `project` */

DROP TABLE IF EXISTS `project`;

CREATE TABLE `project` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectName` varchar(255) NOT NULL,
  `Description` text,
  `HasBRD` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `project` */

/*Table structure for table `score` */

DROP TABLE IF EXISTS `score`;

CREATE TABLE `score` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CriterionId` int(11) NOT NULL,
  `ProjectId` int(11) NOT NULL,
  `Rate` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_project` (`ProjectId`),
  KEY `fk_criterion` (`CriterionId`),
  CONSTRAINT `fk_criterion` FOREIGN KEY (`CriterionId`) REFERENCES `criterion` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `fk_project` FOREIGN KEY (`ProjectId`) REFERENCES `project` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `score` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
