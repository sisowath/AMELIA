-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Nov 15, 2015 at 06:33 PM
-- Server version: 5.6.20-log
-- PHP Version: 5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `katnisseverdeen`
--

-- --------------------------------------------------------

--
-- Table structure for table `bachelor`
--

CREATE TABLE IF NOT EXISTS `bachelor` (
`id` int(11) NOT NULL,
  `username` varchar(100) COLLATE latin1_bin NOT NULL,
  `password` varchar(100) COLLATE latin1_bin NOT NULL,
  `email` varchar(100) COLLATE latin1_bin NOT NULL,
  `numberOfLikes` int(11) NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=6 ;

--
-- Dumping data for table `bachelor`
--

INSERT INTO `bachelor` (`id`, `username`, `password`, `email`, `numberOfLikes`) VALUES
(1, 'samnang', 'suon', 'samnangsuon@admin.com', 999999999),
(2, 'kismony', 'ladouceur', 'kismonyladouceur@admin.com', 999999999),
(3, 'miranda', 'kerr', 'mirandakerr@victoriasecret.com', 864205),
(4, 'candice', 'swanepoel', 'candiceswanepoel@victoriasecret.com', 1086420),
(5, 'michelle', 'keagan', 'michellekeagan@beauty.com', 6804213);

-- --------------------------------------------------------

--
-- Table structure for table `bookgenres`
--

CREATE TABLE IF NOT EXISTS `bookgenres` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Dumping data for table `bookgenres`
--

INSERT INTO `bookgenres` (`id`, `nom`) VALUES
(1, 'roman'),
(2, 'myths'),
(3, 'comedie'),
(4, 'tragedie'),
(5, 'romance'),
(6, 'fable'),
(7, 'science-fiction'),
(8, 'legende'),
(9, 'thriller'),
(10, 'biographie');

-- --------------------------------------------------------

--
-- Table structure for table `brands`
--

CREATE TABLE IF NOT EXISTS `brands` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Dumping data for table `brands`
--

INSERT INTO `brands` (`id`, `nom`) VALUES
(1, 'Apple'),
(2, 'Microsoft'),
(3, 'Google'),
(4, 'Coca-Cola'),
(5, 'McDonald'),
(6, 'Samsung'),
(7, 'intel'),
(8, 'Nike'),
(9, 'Budweiser'),
(10, 'BMW');

-- --------------------------------------------------------

--
-- Table structure for table `hobbies`
--

CREATE TABLE IF NOT EXISTS `hobbies` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Dumping data for table `hobbies`
--

INSERT INTO `hobbies` (`id`, `nom`) VALUES
(1, 'lecture'),
(2, 'television'),
(3, 'shopping'),
(4, 'velo'),
(5, 'camping'),
(6, 'natation'),
(7, 'peinture'),
(8, 'cuisiner'),
(9, 'peche'),
(10, 'programmation');

-- --------------------------------------------------------

--
-- Table structure for table `moviegenres`
--

CREATE TABLE IF NOT EXISTS `moviegenres` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Dumping data for table `moviegenres`
--

INSERT INTO `moviegenres` (`id`, `nom`) VALUES
(1, 'action'),
(2, 'aventure'),
(3, 'animation'),
(4, 'cgi'),
(5, 'comedie'),
(6, 'policier'),
(7, 'horreur'),
(8, 'romantique'),
(9, 'science-fiction'),
(10, 'espion');

-- --------------------------------------------------------

--
-- Table structure for table `musicgenres`
--

CREATE TABLE IF NOT EXISTS `musicgenres` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Dumping data for table `musicgenres`
--

INSERT INTO `musicgenres` (`id`, `nom`) VALUES
(1, 'rock'),
(2, 'blues'),
(3, 'country'),
(4, 'hip hop'),
(5, 'jazz'),
(6, 'reggae'),
(7, 'classique'),
(8, 'techno'),
(9, 'salsa'),
(10, 'pop');

-- --------------------------------------------------------

--
-- Table structure for table `sports`
--

CREATE TABLE IF NOT EXISTS `sports` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Dumping data for table `sports`
--

INSERT INTO `sports` (`id`, `nom`) VALUES
(1, 'soccer'),
(2, 'volleyball'),
(3, 'basketball'),
(4, 'hockey'),
(5, 'badminton'),
(6, 'boxe'),
(7, 'rugby'),
(8, 'patinage'),
(9, 'golf'),
(10, 'judo');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bachelor`
--
ALTER TABLE `bachelor`
 ADD PRIMARY KEY (`id`,`username`);

--
-- Indexes for table `bookgenres`
--
ALTER TABLE `bookgenres`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `brands`
--
ALTER TABLE `brands`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `hobbies`
--
ALTER TABLE `hobbies`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `moviegenres`
--
ALTER TABLE `moviegenres`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `musicgenres`
--
ALTER TABLE `musicgenres`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sports`
--
ALTER TABLE `sports`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bachelor`
--
ALTER TABLE `bachelor`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `bookgenres`
--
ALTER TABLE `bookgenres`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `brands`
--
ALTER TABLE `brands`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `hobbies`
--
ALTER TABLE `hobbies`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `moviegenres`
--
ALTER TABLE `moviegenres`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `musicgenres`
--
ALTER TABLE `musicgenres`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `sports`
--
ALTER TABLE `sports`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
