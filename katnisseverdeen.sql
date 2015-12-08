-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Mer 02 Décembre 2015 à 15:09
-- Version du serveur :  5.6.20-log
-- Version de PHP :  5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `katnisseverdeen`
--

-- --------------------------------------------------------

--
-- Structure de la table `bachelor`
--

CREATE TABLE IF NOT EXISTS `bachelor` (
`id` int(11) NOT NULL,
  `username` varchar(100) COLLATE latin1_bin NOT NULL,
  `password` varchar(100) COLLATE latin1_bin NOT NULL,
  `email` varchar(100) COLLATE latin1_bin NOT NULL,
  `numberOfLikes` int(11) NOT NULL,
  `image` varchar(100) COLLATE latin1_bin NOT NULL,
  `idbookgenres` int(11) NOT NULL,
  `idbrands` int(11) NOT NULL,
  `idhobbies` int(11) NOT NULL,
  `idmoviegenres` int(11) NOT NULL,
  `idmusicgenres` int(11) NOT NULL,
  `idsports` int(11) NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=537 ;

--
-- Contenu de la table `bachelor`
--

INSERT INTO `bachelor` (`id`, `username`, `password`, `email`, `numberOfLikes`, `image`, `idbookgenres`, `idbrands`, `idhobbies`, `idmoviegenres`, `idmusicgenres`, `idsports`) VALUES
(1, 'samnang', 'suon', 'samnang@amelia.com', 999999999, '~/images/zeus.jpg', 1, 2, 3, 4, 5, 6),
(2, 'kismony', 'ladouceur', 'kismonyladouceur@admin.com', 99999999, '~/images/katnisseverdeen.jpg', 7, 8, 9, 10, 1, 2),
(3, 'miranda', 'kerr', 'mirandakerr@victoriasecret.com', 864205, '~/images/miranda_kerr.jpg', 5, 6, 7, 8, 9, 10),
(4, 'candice', 'swanepoel', 'candiceswanepoel@victoriasecret.com', 1086421, '~/images/candice_swanepoel.jpg', 1, 2, 3, 4, 5, 6),
(5, 'michelle', 'keegan', 'michellekeagan@beauty.com', 6804213, '~/images/michelle_keegan.jpg', 3, 4, 5, 6, 7, 8),
(10, 'Marsden', 'Leo', 'Aliquam@temporbibendumDonec.net', 325847, '~/images/katnisseverdeen.jpg', 3, 3, 9, 10, 2, 1),
(9, 'Britanni', 'Priscilla', 'varius.ultrices@blanditviverra.org', 16562, '~/images/katnisseverdeen.jpg', 10, 2, 9, 6, 1, 1),
(8, 'Demetria', 'Kathleen', 'arcu.vel@a.ca', 672981, '~/images/katnisseverdeen.jpg', 4, 5, 3, 2, 1, 2),
(7, 'Ferdinand', 'Erich', 'eu.arcu@liberomaurisaliquam.org', 84476, '~/images/katnisseverdeen.jpg', 2, 3, 1, 7, 6, 6),
(6, 'Katelyn', 'Herman', 'dignissim.lacus.Aliquam@sempererat.com', 426221, '~/images/katnisseverdeen.jpg', 3, 8, 8, 5, 9, 5),
(535, 'bob', 'jones', 'bob', 0, '~/images/exam.txt', 0, 0, 0, 0, 0, 0),
(536, 'jasper', 'test', 'jasperD@hotmail.com', 0, '~/images/tumblr_noof75boGl1uttoqvo1_500.gif', 1, 1, 1, 1, 4, 1),
(534, 'caitlyn', 'test', 'jennerC', 0, '~/images/Caitlyn_Jenner_2_Photo_800.jpg', 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Structure de la table `bookgenres`
--

CREATE TABLE IF NOT EXISTS `bookgenres` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Contenu de la table `bookgenres`
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
-- Structure de la table `brands`
--

CREATE TABLE IF NOT EXISTS `brands` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Contenu de la table `brands`
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
-- Structure de la table `credit`
--

CREATE TABLE IF NOT EXISTS `credit` (
  `numeroCarte` int(20) NOT NULL DEFAULT '0',
  `nomCarte` varchar(200) NOT NULL,
  `codeSecurite` int(3) NOT NULL,
  `dateExpiration` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Contenu de la table `credit`
--

INSERT INTO `credit` (`numeroCarte`, `nomCarte`, `codeSecurite`, `dateExpiration`) VALUES
(2147483647, 'Symphorein peke', 545, '10/2018');

-- --------------------------------------------------------

--
-- Structure de la table `hobbies`
--

CREATE TABLE IF NOT EXISTS `hobbies` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Contenu de la table `hobbies`
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
-- Structure de la table `moviegenres`
--

CREATE TABLE IF NOT EXISTS `moviegenres` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Contenu de la table `moviegenres`
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
-- Structure de la table `musicgenres`
--

CREATE TABLE IF NOT EXISTS `musicgenres` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Contenu de la table `musicgenres`
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
-- Structure de la table `sports`
--

CREATE TABLE IF NOT EXISTS `sports` (
`id` int(11) NOT NULL,
  `nom` varchar(100) COLLATE latin1_bin NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Contenu de la table `sports`
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
-- Index pour les tables exportées
--

--
-- Index pour la table `bachelor`
--
ALTER TABLE `bachelor`
 ADD PRIMARY KEY (`id`,`username`);

--
-- Index pour la table `bookgenres`
--
ALTER TABLE `bookgenres`
 ADD PRIMARY KEY (`id`);

--
-- Index pour la table `brands`
--
ALTER TABLE `brands`
 ADD PRIMARY KEY (`id`);

--
-- Index pour la table `credit`
--
ALTER TABLE `credit`
 ADD PRIMARY KEY (`numeroCarte`);

--
-- Index pour la table `hobbies`
--
ALTER TABLE `hobbies`
 ADD PRIMARY KEY (`id`);

--
-- Index pour la table `moviegenres`
--
ALTER TABLE `moviegenres`
 ADD PRIMARY KEY (`id`);

--
-- Index pour la table `musicgenres`
--
ALTER TABLE `musicgenres`
 ADD PRIMARY KEY (`id`);

--
-- Index pour la table `sports`
--
ALTER TABLE `sports`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `bachelor`
--
ALTER TABLE `bachelor`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=537;
--
-- AUTO_INCREMENT pour la table `bookgenres`
--
ALTER TABLE `bookgenres`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `brands`
--
ALTER TABLE `brands`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `hobbies`
--
ALTER TABLE `hobbies`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `moviegenres`
--
ALTER TABLE `moviegenres`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `musicgenres`
--
ALTER TABLE `musicgenres`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `sports`
--
ALTER TABLE `sports`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
