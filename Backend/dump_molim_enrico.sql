-- --------------------------------------------------------
-- Host:                         10.1.148.36
-- Versione server:              10.5.9-MariaDB - mariadb.org binary distribution
-- S.O. server:                  Win64
-- HeidiSQL Versione:            11.1.0.6116
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database information_schema

-- Dump della struttura del database molim
CREATE DATABASE IF NOT EXISTS `molim_backup_enrico` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `molim_backup_enrico`;

-- Dump della struttura di tabella molim.accounts
CREATE TABLE IF NOT EXISTS `accounts` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TipoRuolo` varchar(20) DEFAULT NULL,
  `Username` varchar(100) DEFAULT NULL,
  `Password` text DEFAULT NULL,
  `Cognome` varchar(250) DEFAULT NULL,
  `Nome` varchar(250) DEFAULT NULL,
  `Version` bigint(20) NOT NULL,
  `CreatorAccount_ID` int(11) DEFAULT NULL,
  `UpdaterAccount_ID` int(11) DEFAULT NULL,
  `CreationDate` datetime NOT NULL,
  `LastUpdateDate` datetime NOT NULL,
  `ResetPassword` tinyint(1) NOT NULL,
  `Deleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_Accounts_TipoRuolo` (`TipoRuolo`),
  CONSTRAINT `fk_account_role` FOREIGN KEY (`TipoRuolo`) REFERENCES `profili` (`Tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.accounts: ~0 rows (circa)
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;

-- Dump della struttura di tabella molim.normalizzazione_risultati_test
CREATE TABLE IF NOT EXISTS `normalizzazione_risultati_test` (
  `da_valore` decimal(5,2) NOT NULL,
  `a_valore` decimal(5,2) NOT NULL,
  `valore_normalizzato` int(11) NOT NULL,
  `id_test` varchar(10) NOT NULL,
  KEY `normalizzazione_risultati_test_id_test_fkey` (`id_test`),
  CONSTRAINT `normalizzazione_risultati_test_id_test_fkey` FOREIGN KEY (`id_test`) REFERENCES `test_neurologici` (`id_test`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.normalizzazione_risultati_test: ~114 rows (circa)
/*!40000 ALTER TABLE `normalizzazione_risultati_test` DISABLE KEYS */;
INSERT INTO `normalizzazione_risultati_test` (`da_valore`, `a_valore`, `valore_normalizzato`, `id_test`) VALUES
	(0.00, 4.00, 0, 'UPDRS_I'),
	(5.00, 8.00, 1, 'UPDRS_I'),
	(9.00, 11.00, 2, 'UPDRS_I'),
	(12.00, 13.00, 3, 'UPDRS_I'),
	(14.00, 46.00, 4, 'UPDRS_I'),
	(0.00, 13.00, 0, 'UPDRS_II'),
	(14.00, 26.00, 1, 'UPDRS_II'),
	(27.00, 39.00, 2, 'UPDRS_II'),
	(40.00, 45.00, 3, 'UPDRS_II'),
	(46.00, 52.00, 4, 'UPDRS_II'),
	(0.00, 14.00, 0, 'UPDRS_III'),
	(15.00, 28.00, 1, 'UPDRS_III'),
	(29.00, 42.00, 2, 'UPDRS_III'),
	(43.00, 49.00, 3, 'UPDRS_III'),
	(50.00, 56.00, 4, 'UPDRS_III'),
	(0.00, 11.00, 0, 'UPDRS_IV'),
	(12.00, 22.00, 1, 'UPDRS_IV'),
	(23.00, 33.00, 2, 'UPDRS_IV'),
	(34.00, 39.00, 3, 'UPDRS_IV'),
	(40.00, 44.00, 4, 'UPDRS_IV'),
	(0.00, 0.00, 0, 'HeY'),
	(1.00, 1.50, 1, 'HeY'),
	(2.00, 2.50, 2, 'HeY'),
	(3.00, 3.50, 3, 'HeY'),
	(4.00, 36.00, 4, 'HeY'),
	(0.00, 8.00, 0, 'MMSE'),
	(9.00, 17.00, 1, 'MMSE'),
	(18.00, 24.00, 2, 'MMSE'),
	(25.00, 27.00, 3, 'MMSE'),
	(28.00, 56.00, 4, 'MMSE'),
	(0.00, 8.00, 0, 'TOKEN'),
	(9.00, 16.00, 1, 'TOKEN'),
	(17.00, 24.00, 2, 'TOKEN'),
	(25.00, 28.00, 3, 'TOKEN'),
	(29.00, 56.00, 4, 'TOKEN'),
	(0.00, 14.00, 0, 'COWAT'),
	(15.00, 70.00, 1, 'COWAT'),
	(71.00, 85.00, 2, 'COWAT'),
	(85.00, 100.00, 3, 'COWAT'),
	(101.00, 130.00, 4, 'COWAT'),
	(0.00, 28.00, 0, 'RAVLT_RI'),
	(29.00, 75.00, 4, 'RAVLT_RI'),
	(0.00, 5.00, 0, 'RAVLT_RD'),
	(6.00, 15.00, 1, 'RAVLT_RD'),
	(16.00, 24.00, 2, 'RAVLT_RD'),
	(25.00, 30.00, 3, 'RAVLT_RD'),
	(31.00, 36.00, 4, 'RAVLT_RD'),
	(0.00, 19.00, 0, 'FCSRT_IFR'),
	(20.00, 23.00, 1, 'FCSRT_IFR'),
	(24.00, 25.00, 2, 'FCSRT_IFR'),
	(26.00, 28.00, 3, 'FCSRT_IFR'),
	(29.00, 36.00, 4, 'FCSRT_IFR'),
	(0.00, 34.00, 0, 'FCSRT_ITR'),
	(35.00, 36.00, 4, 'FCSRT_ITR'),
	(0.00, 5.00, 0, 'FCSRT_DFR'),
	(6.00, 7.00, 1, 'FCSRT_DFR'),
	(8.00, 9.00, 2, 'FCSRT_DFR'),
	(10.00, 10.00, 3, 'FCSRT_DFR'),
	(11.00, 12.00, 4, 'FCSRT_DFR'),
	(0.00, 11.00, 0, 'FCSRT_DTR'),
	(12.00, 12.00, 4, 'FCSRT_DTR'),
	(0.00, 0.90, 0, 'FCSRT_ISC'),
	(1.00, 5.00, 1, 'FCSRT_ISC'),
	(6.00, 10.00, 2, 'FCSRT_ISC'),
	(11.00, 15.00, 3, 'FCSRT_ISC'),
	(16.00, 625.00, 4, 'FCSRT_ISC'),
	(0.00, 3.00, 1, 'DIGIT_FW'),
	(4.00, 12.00, 2, 'DIGIT_FW'),
	(13.00, 29.00, 3, 'DIGIT_FW'),
	(30.00, 36.00, 4, 'DIGIT_FW'),
	(0.00, 1.00, 1, 'DIGIT_BW'),
	(2.00, 12.00, 2, 'DIGIT_BW'),
	(13.00, 19.00, 3, 'DIGIT_BW'),
	(20.00, 23.00, 4, 'DIGIT_BW'),
	(0.00, 13.00, 0, 'FAB'),
	(14.00, 20.00, 1, 'FAB'),
	(21.00, 29.00, 2, 'FAB'),
	(30.00, 33.00, 3, 'FAB'),
	(34.00, 36.00, 4, 'FAB'),
	(0.00, 10.00, 0, 'STROOP_W'),
	(11.00, 32.00, 1, 'STROOP_W'),
	(33.00, 57.00, 2, 'STROOP_W'),
	(58.00, 91.00, 3, 'STROOP_W'),
	(92.00, 97.00, 4, 'STROOP_W'),
	(0.00, 19.00, 0, 'STROOP_C'),
	(20.00, 25.00, 1, 'STROOP_C'),
	(26.00, 33.00, 2, 'STROOP_C'),
	(34.00, 48.00, 3, 'STROOP_C'),
	(39.00, 50.00, 4, 'STROOP_C'),
	(0.00, 20.00, 0, 'STROOP_CW'),
	(21.00, 30.00, 1, 'STROOP_CW'),
	(31.00, 35.00, 2, 'STROOP_CW'),
	(36.00, 40.00, 3, 'STROOP_CW'),
	(41.00, 100.00, 4, 'STROOP_CW'),
	(0.00, 7.00, 0, 'WEIGL'),
	(8.00, 9.00, 1, 'WEIGL'),
	(10.00, 11.00, 2, 'WEIGL'),
	(12.00, 13.00, 3, 'WEIGL'),
	(14.00, 30.00, 4, 'WEIGL'),
	(0.00, 14.00, 0, 'JLO_V'),
	(15.00, 17.00, 1, 'JLO_V'),
	(18.00, 20.00, 2, 'JLO_V'),
	(21.00, 24.00, 3, 'JLO_V'),
	(25.00, 28.00, 4, 'JLO_V'),
	(5.00, 9.00, 4, 'BECK_II'),
	(10.00, 18.00, 3, 'BECK_II'),
	(19.00, 24.00, 2, 'BECK_II'),
	(25.00, 29.00, 1, 'BECK_II'),
	(30.00, 63.00, 0, 'BECK_II'),
	(0.00, 0.00, 4, 'HAMA'),
	(1.00, 17.00, 3, 'HAMA'),
	(18.00, 24.00, 2, 'HAMA'),
	(25.00, 30.00, 1, 'HAMA'),
	(31.00, 56.00, 0, 'HAMA');
/*!40000 ALTER TABLE `normalizzazione_risultati_test` ENABLE KEYS */;

-- Dump della struttura di tabella molim.paziente
CREATE TABLE IF NOT EXISTS `paziente` (
  `id_paziente` varchar(25) NOT NULL,
  `id_progetto` varchar(3) NOT NULL,
  `nome_paziente` varchar(20) DEFAULT NULL,
  `cognome_paziente` varchar(20) DEFAULT NULL,
  `anno_nascita` int(11) NOT NULL,
  `sesso` char(1) NOT NULL,
  `city` varchar(20) DEFAULT NULL,
  `codice_fiscale` varchar(16) DEFAULT NULL,
  `indirizzo` varchar(20) DEFAULT NULL,
  `indirizzo_mail` varchar(25) DEFAULT NULL,
  `numero_cellulare` int(11) DEFAULT NULL,
  `education` int(11) DEFAULT NULL,
  `stile_di_vita` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_paziente`,`id_progetto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.paziente: ~254 rows (circa)
/*!40000 ALTER TABLE `paziente` DISABLE KEYS */;
INSERT INTO `paziente` (`id_paziente`, `id_progetto`, `nome_paziente`, `cognome_paziente`, `anno_nascita`, `sesso`, `city`, `codice_fiscale`, `indirizzo`, `indirizzo_mail`, `numero_cellulare`, `education`, `stile_di_vita`) VALUES
	('SDN_AMY_AD_005', 'NAD', '', '', 1953, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_007', 'NAD', '', '', 1945, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_008', 'NAD', '', '', 1944, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_009', 'NAD', '', '', 1935, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_010', 'NAD', '', '', 1935, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_011', 'NAD', '', '', 1962, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_012', 'NAD', '', '', 1947, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_013', 'NAD', '', '', 1964, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_014', 'NAD', '', '', 1955, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_016', 'NAD', '', '', 1959, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_017', 'NAD', '', '', 1952, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_018', 'NAD', '', '', 1944, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_019', 'NAD', '', '', 1961, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_020', 'NAD', '', '', 1955, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_025', 'NAD', '', '', 1959, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_028', 'NAD', '', '', 1952, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_034', 'NAD', '', '', 1946, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_054', 'NAD', '', '', 1942, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_073', 'NAD', '', '', 1952, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_078', 'NAD', '', '', 1959, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_080', 'NAD', '', '', 1963, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_081', 'NAD', '', '', 1943, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_082', 'NAD', '', '', 1935, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_088', 'NAD', '', '', 1945, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_093', 'NAD', '', '', 1944, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_094', 'NAD', '', '', 1949, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_AD_099', 'NAD', '', '', 1969, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_001', 'NPD', '', '', 1959, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_015', 'NPD', '', '', 1955, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_051', 'NPD', '', '', 1955, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_052', 'NPD', '', '', 1963, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_055', 'NPD', '', '', 1963, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_064', 'NPD', '', '', 1959, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_075', 'NPD', '', '', 1956, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_076', 'NPD', '', '', 1951, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_077', 'NPD', '', '', 1960, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_079', 'NPD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_083', 'NPD', '', '', 1961, 'F', '', '', '', '', 0, 0, ''),
	('SDN_AMY_PD_096', 'NPD', '', '', 1945, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_003', 'NAD', '', '', 1952, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_004', 'NAD', '', '', 1944, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_026', 'NAD', '', '', 1971, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_027', 'NAD', '', '', 1941, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_030', 'NAD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_031', 'NAD', '', '', 1958, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_046', 'NAD', '', '', 1949, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_053', 'NAD', '', '', 1943, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_056', 'NAD', '', '', 1971, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_057', 'NAD', '', '', 1942, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_061', 'NAD', '', '', 1955, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_063', 'NAD', '', '', 1955, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_066', 'NAD', '', '', 1959, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_069', 'NAD', '', '', 1942, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_072', 'NAD', '', '', 1956, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_074', 'NAD', '', '', 1953, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_087', 'NAD', '', '', 1960, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_095', 'NAD', '', '', 1950, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_AD_098', 'NAD', '', '', 1955, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_002', 'NPD', '', '', 1953, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_006', 'NPD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_021', 'NPD', '', '', 1943, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_022', 'NPD', '', '', 1956, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_023', 'NPD', '', '', 1955, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_024', 'NPD', '', '', 1941, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_029', 'NPD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_032', 'NPD', '', '', 1943, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_033', 'NPD', '', '', 1951, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_035', 'NPD', '', '', 1963, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_036', 'NPD', '', '', 1947, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_037', 'NPD', '', '', 1954, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_038', 'NPD', '', '', 1956, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_039', 'NPD', '', '', 1952, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_040', 'NPD', '', '', 1965, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_041', 'NPD', '', '', 1954, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_042', 'NPD', '', '', 1954, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_043', 'NPD', '', '', 1954, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_044', 'NPD', '', '', 1970, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_045', 'NPD', '', '', 1960, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_047', 'NPD', '', '', 2021, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_048', 'NPD', '', '', 1953, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_049', 'NPD', '', '', 1950, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_050', 'NPD', '', '', 1951, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_058', 'NPD', '', '', 1969, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_059', 'NPD', '', '', 1952, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_060', 'NPD', '', '', 1970, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_062', 'NPD', '', '', 1950, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_065', 'NPD', '', '', 1969, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_067', 'NPD', '', '', 1954, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_068', 'NPD', '', '', 1962, 'F', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_070', 'NPD', '', '', 1959, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_071', 'NPD', '', '', 1963, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_084', 'NPD', '', '', 1952, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_086', 'NPD', '', '', 1942, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_089', 'NPD', '', '', 1955, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_090', 'NPD', '', '', 1945, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_091', 'NPD', '', '', 1960, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_092', 'NPD', '', '', 1943, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_097', 'NPD', '', '', 1971, 'M', '', '', '', '', 0, 0, ''),
	('SDN_FDG_PD_100', 'NPD', '', '', 1947, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_001', 'NAD', '', '', 1944, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_002', 'NAD', '', '', 1941, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_003', 'NAD', '', '', 1938, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_004', 'NAD', '', '', 1933, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_005', 'NAD', '', '', 1945, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_006', 'NAD', '', '', 1944, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_007', 'NAD', '', '', 1942, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_008', 'NAD', '', '', 1966, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_009', 'NAD', '', '', 1958, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_010', 'NAD', '', '', 1943, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_011', 'NAD', '', '', 1950, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_012', 'NAD', '', '', 1964, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_013', 'NAD', '', '', 1946, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_014', 'NAD', '', '', 1962, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_015', 'NAD', '', '', 1962, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_016', 'NAD', '', '', 1940, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_017', 'NAD', '', '', 1949, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_018', 'NAD', '', '', 1947, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_019', 'NAD', '', '', 1940, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_020', 'NAD', '', '', 1948, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_021', 'NAD', '', '', 1954, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_022', 'NAD', '', '', 1942, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_023', 'NAD', '', '', 1943, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_024', 'NAD', '', '', 1937, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_025', 'NAD', '', '', 1947, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_026', 'NAD', '', '', 1949, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_027', 'NAD', '', '', 1959, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_028', 'NAD', '', '', 1939, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_029', 'NAD', '', '', 1953, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_030', 'NAD', '', '', 1954, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_031', 'NAD', '', '', 1945, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_032', 'NAD', '', '', 1941, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_033', 'NAD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_034', 'NAD', '', '', 1946, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_035', 'NAD', '', '', 1954, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_036', 'NAD', '', '', 1961, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_037', 'NAD', '', '', 1948, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_038', 'NAD', '', '', 1942, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_039', 'NAD', '', '', 1938, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_040', 'NAD', '', '', 1962, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_041', 'NAD', '', '', 1955, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_042', 'NAD', '', '', 1951, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_AD_043', 'NAD', '', '', 1953, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_001', 'NAD', '', '', 1945, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_002', 'NAD', '', '', 1962, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_003', 'NAD', '', '', 1936, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_004', 'NAD', '', '', 1958, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_005', 'NAD', '', '', 1947, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_006', 'NAD', '', '', 1969, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_007', 'NAD', '', '', 1969, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_008', 'NAD', '', '', 1961, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_009', 'NAD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_010', 'NAD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_011', 'NAD', '', '', 1951, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_012', 'NAD', '', '', 1949, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_013', 'NAD', '', '', 1961, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_014', 'NAD', '', '', 1937, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_015', 'NAD', '', '', 1973, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_016', 'NAD', '', '', 1956, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_017', 'NAD', '', '', 1965, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_018', 'NAD', '', '', 1942, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_019', 'NAD', '', '', 1953, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_020', 'NAD', '', '', 1952, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_021', 'NAD', '', '', 1956, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_022', 'NAD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_023', 'NAD', '', '', 1944, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_024', 'NAD', '', '', 1967, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_025', 'NAD', '', '', 1933, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_026', 'NAD', '', '', 1954, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_027', 'NAD', '', '', 1975, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_028', 'NAD', '', '', 1951, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_029', 'NAD', '', '', 1967, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_030', 'NAD', '', '', 1941, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_031', 'NAD', '', '', 1955, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_032', 'NAD', '', '', 1949, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_033', 'NAD', '', '', 1946, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_034', 'NAD', '', '', 1964, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_035', 'NAD', '', '', 1950, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_036', 'NAD', '', '', 1943, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_037', 'NAD', '', '', 1938, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_038', 'NAD', '', '', 1952, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_039', 'NAD', '', '', 1961, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_040', 'NAD', '', '', 1964, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_041', 'NAD', '', '', 1967, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_042', 'NAD', '', '', 1963, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_043', 'NAD', '', '', 1949, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_044', 'NAD', '', '', 1979, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_045', 'NAD', '', '', 1959, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_046', 'NAD', '', '', 1958, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_047', 'NAD', '', '', 1941, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_048', 'NAD', '', '', 1957, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_049', 'NAD', '', '', 1956, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_050', 'NAD', '', '', 1948, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDG_CTRL_051', 'NAD', '', '', 1948, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_001', 'NPD', '', '', 1950, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_002', 'NPD', '', '', 1955, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_003', 'NPD', '', '', 1939, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_004', 'NPD', '', '', 1951, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_005', 'NPD', '', '', 1949, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_006', 'NPD', '', '', 1939, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_007', 'NPD', '', '', 1971, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_008', 'NPD', '', '', 1946, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_009', 'NPD', '', '', 1958, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_010', 'NPD', '', '', 1953, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_011', 'NPD', '', '', 1944, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_012', 'NPD', '', '', 1941, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_013', 'NPD', '', '', 1946, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_CTRL_014', 'NPD', '', '', 1946, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_001', 'NPD', '', '', 1969, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_002', 'NPD', '', '', 1948, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_003', 'NPD', '', '', 1953, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_004', 'NPD', '', '', 1956, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_005', 'NPD', '', '', 1952, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_006', 'NPD', '', '', 1961, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_007', 'NPD', '', '', 1950, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_008', 'NPD', '', '', 1954, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_009', 'NPD', '', '', 1967, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_010', 'NPD', '', '', 1962, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_011', 'NPD', '', '', 1948, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_012', 'NPD', '', '', 1946, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_013', 'NPD', '', '', 1954, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_014', 'NPD', '', '', 1961, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_015', 'NPD', '', '', 1953, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_016', 'NPD', '', '', 1943, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_017', 'NPD', '', '', 1949, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_018', 'NPD', '', '', 1970, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_019', 'NPD', '', '', 1957, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_020', 'NPD', '', '', 1951, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_021', 'NPD', '', '', 1958, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_022', 'NPD', '', '', 1961, 'F', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_023', 'NPD', '', '', 1958, 'M', '', '', '', '', 0, 0, ''),
	('UNICZ_FDOPA_PD_024', 'NPD', '', '', 1973, 'M', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_014', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_015', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_016', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_017', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_018', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_019', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_020', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_021', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_022', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_AMY_AD_023', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_001', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_002', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_003', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_004', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_005', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_006', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_007', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_008', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_009', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_010', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_011', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_012', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, ''),
	('UNIME_FDG_AD_013', 'NAD', '', '', 2021, 'U', '', '', '', '', 0, 0, '');
/*!40000 ALTER TABLE `paziente` ENABLE KEYS */;

-- Dump della struttura di tabella molim.permessiprofili
CREATE TABLE IF NOT EXISTS `permessiprofili` (
  `TipoRuolo` varchar(20) NOT NULL,
  `Permesso` varchar(50) NOT NULL,
  `CreatorAccount_ID` int(11) DEFAULT NULL,
  `UpdaterAccount_ID` int(11) DEFAULT NULL,
  `CreationDate` datetime NOT NULL,
  `LastUpdateDate` datetime NOT NULL,
  PRIMARY KEY (`TipoRuolo`,`Permesso`),
  CONSTRAINT `fk_roles_permissions` FOREIGN KEY (`TipoRuolo`) REFERENCES `profili` (`Tipo`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.permessiprofili: ~0 rows (circa)
/*!40000 ALTER TABLE `permessiprofili` DISABLE KEYS */;
/*!40000 ALTER TABLE `permessiprofili` ENABLE KEYS */;

-- Dump della struttura di tabella molim.profili
CREATE TABLE IF NOT EXISTS `profili` (
  `Tipo` varchar(20) NOT NULL,
  `Descrizione` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.profili: ~0 rows (circa)
/*!40000 ALTER TABLE `profili` DISABLE KEYS */;
/*!40000 ALTER TABLE `profili` ENABLE KEYS */;

-- Dump della struttura di tabella molim.progetti
CREATE TABLE IF NOT EXISTS `progetti` (
  `id_progetto` char(3) NOT NULL,
  `descrizione` char(50) NOT NULL,
  PRIMARY KEY (`id_progetto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.progetti: ~4 rows (circa)
/*!40000 ALTER TABLE `progetti` DISABLE KEYS */;
INSERT INTO `progetti` (`id_progetto`, `descrizione`) VALUES
	('NAD', 'NeuroAlzheimerDisease'),
	('NPD', 'NeuroParkinsonDisease'),
	('ONB', 'OncoBreast'),
	('ONC', 'OncoColon');
/*!40000 ALTER TABLE `progetti` ENABLE KEYS */;

-- Dump della struttura di tabella molim.progettitest
CREATE TABLE IF NOT EXISTS `progettitest` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `IdTest` varchar(50) NOT NULL,
  `IdProgetto` varchar(5) NOT NULL,
  `TipoValore` int(11) NOT NULL,
  `IdTipoTest` varchar(5) NOT NULL,
  `IdClusterTest` varchar(5) DEFAULT NULL,
  `Descrizione` varchar(100) NOT NULL,
  `DataInizioValidita` datetime DEFAULT NULL,
  `DataFineValidita` datetime DEFAULT NULL,
  `ValoreMin` int(11) DEFAULT NULL,
  `ValoreMax` int(11) DEFAULT NULL,
  `Regex` text DEFAULT NULL,
  `CreatorAccount_ID` int(11) DEFAULT NULL,
  `UpdaterAccount_ID` int(11) DEFAULT NULL,
  `CreationDate` datetime NOT NULL,
  `LastUpdateDate` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.progettitest: ~71 rows (circa)
/*!40000 ALTER TABLE `progettitest` DISABLE KEYS */;
INSERT INTO `progettitest` (`ID`, `IdTest`, `IdProgetto`, `TipoValore`, `IdTipoTest`, `IdClusterTest`, `Descrizione`, `DataInizioValidita`, `DataFineValidita`, `ValoreMin`, `ValoreMax`, `Regex`, `CreatorAccount_ID`, `UpdaterAccount_ID`, `CreationDate`, `LastUpdateDate`) VALUES
	(2, 'BECK_II', 'NPD', 0, 'NEURO', 'COGNT', 'Beck Depression', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(3, 'COWAT', 'NPD', 0, 'NEURO', 'COGNT', 'Controlled Oral Word Association Test', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(4, 'COWAT', 'NAD', 0, 'NEURO', 'COGNT', 'Controlled Oral Word Association Test', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(5, 'DIGIT_BW', 'NPD', 0, 'NEURO', 'COGNT', 'Backward digit', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(6, 'DIGIT_BW', 'NAD', 0, 'NEURO', 'COGNT', 'Backward digit', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(7, 'DIGIT_FW', 'NPD', 0, 'NEURO', 'COGNT', 'Forward digit', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(8, 'DIGIT_FW', 'NAD', 0, 'NEURO', 'COGNT', 'Forward digit', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(9, 'FAB', 'NPD', 0, 'NEURO', 'COGNT', 'FRONTAL ASSESSEMENT BATTERY (FAB)', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(10, 'FAB', 'NAD', 0, 'NEURO', 'COGNT', 'FRONTAL ASSESSEMENT BATTERY (FAB)', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(11, 'FCSRT_DFR', 'NPD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione differita libera', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(12, 'FCSRT_DFR', 'NAD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione differita libera', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(13, 'FCSRT_DTR', 'NPD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione differita totale', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(14, 'FCSRT_DTR', 'NAD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione differita totale', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(15, 'FCSRT_IFR', 'NPD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione libera immediata', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(16, 'FCSRT_IFR', 'NAD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione libera immediata', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(17, 'FCSRT_ISC', 'NPD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Indice di sensibilita\' al suggerimento semantico', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(18, 'FCSRT_ISC', 'NAD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Indice di sensibilita\' al suggerimento semantico', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(19, 'FCSRT_ITR', 'NPD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione immediata totale', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(20, 'FCSRT_ITR', 'NAD', 0, 'NEURO', 'COGNT', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione immediata totale', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(21, 'HAMA', 'NPD', 0, 'NEURO', 'COGNT', 'HAMA total score', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(22, 'HeY', 'NPD', 0, 'NEURO', 'MOTOR', 'Stadiazione clinica Hoehn e Yahr (HeY)', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(23, 'JLO_V', 'NPD', 0, 'NEURO', 'COGNT', 'Judgment of line orientation', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(24, 'JLO_V', 'NAD', 0, 'NEURO', 'COGNT', 'Judgment of line orientation', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(25, 'MMSE', 'NPD', 0, 'NEURO', 'MOTOR', 'Mini-Mental State Examination', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(26, 'MMSE', 'NAD', 0, 'NEURO', 'MOTOR', 'Mini-Mental State Examination', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(27, 'RAVLT_RD', 'NPD', 0, 'NEURO', 'COGNT', 'Rey Auditory Verbal Learning Test - Rievocazione Differita', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(28, 'RAVLT_RD', 'NAD', 0, 'NEURO', 'COGNT', 'Rey Auditory Verbal Learning Test - Rievocazione Differita', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(29, 'RAVLT_RI', 'NPD', 0, 'NEURO', 'COGNT', 'Rey Auditory Verbal Learning Test  - Rievocazione Immediata', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(30, 'RAVLT_RI', 'NAD', 0, 'NEURO', 'COGNT', 'Rey Auditory Verbal Learning Test  - Rievocazione Immediata', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(31, 'STROOP_C', 'NPD', 0, 'NEURO', 'COGNT', 'Stroop  Test Color', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(32, 'STROOP_C', 'NAD', 0, 'NEURO', 'COGNT', 'Stroop  Test Color', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(33, 'STROOP_CW', 'NPD', 0, 'NEURO', 'COGNT', 'Stroop  Test Color and Word', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(34, 'STROOP_CW', 'NAD', 0, 'NEURO', 'COGNT', 'Stroop  Test Color and Word', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(35, 'STROOP_W', 'NPD', 0, 'NEURO', 'COGNT', 'Stroop  Test Word', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(36, 'STROOP_W', 'NAD', 0, 'NEURO', 'COGNT', 'Stroop  Test Word', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(37, 'TOKEN', 'NPD', 0, 'NEURO', 'COGNT', 'Token test', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(38, 'TOKEN', 'NAD', 0, 'NEURO', 'COGNT', 'Token test', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(39, 'UPDRS_I', 'NPD', 0, 'NEURO', 'MOTOR', 'Stato mentale, comportamentale e timico', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(40, 'UPDRS_II', 'NPD', 0, 'NEURO', 'MOTOR', 'Attivita\' della vita quotidiana (M-EDL)', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(41, 'UPDRS_III', 'NPD', 0, 'NEURO', 'MOTOR', 'Esame Motorio', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(42, 'UPDRS_IV', 'NPD', 0, 'NEURO', 'MOTOR', 'Complicanze Motorie', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(43, 'WEIGL', 'NPD', 0, 'NEURO', 'COGNT', 'Test di Weigl', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(44, 'WEIGL', 'NAD', 0, 'NEURO', 'COGNT', 'Test di Weigl', '2020-01-01 00:00:00', '2021-12-31 00:00:00', NULL, NULL, NULL, NULL, NULL, '2021-05-19 15:56:17', '2021-05-19 15:56:17'),
	(45, 'AMYLOID_PRESENC', 'NAD', 0, 'RADIO', NULL, 'amyloid_presence', NULL, NULL, 0, 1, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(46, 'R_PARIETAL', 'NAD', 0, 'RADIO', NULL, 'Right side Parietal Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(47, 'L_PARIETAL', 'NAD', 0, 'RADIO', NULL, 'Left sise Parietal Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(48, 'R_OCCIPITAL', 'NAD', 0, 'RADIO', NULL, 'Right side Occipital Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(49, 'L_OCCIPITAL', 'NAD', 0, 'RADIO', NULL, 'Left sise Occipital Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(50, 'R_TEMPORAL', 'NAD', 0, 'RADIO', NULL, 'Right side Temporal Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(51, 'L_TEMPORAL', 'NAD', 0, 'RADIO', NULL, 'Left sise Temporal Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(52, 'R_FRONTAL', 'NAD', 0, 'RADIO', NULL, 'Right side Frontal Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(53, 'L_FRONTAL', 'NAD', 0, 'RADIO', NULL, 'Left sise Frontal Lobe', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(54, 'R_LIMBICCORTEX', 'NAD', 0, 'RADIO', NULL, 'Right side Limbic Cortex', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(55, 'L_LIMBICCORTEX', 'NAD', 0, 'RADIO', NULL, 'Left side Limbic Cortex', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(56, 'R_HIPPOCAMPUS', 'NAD', 0, 'RADIO', NULL, 'Right side Hippocampus', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(57, 'L_HIPPOCAMPUS', 'NAD', 0, 'RADIO', NULL, 'Left side Hippocampus', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(58, 'R_AMYGDALA', 'NAD', 0, 'RADIO', NULL, 'Right side Amygdala', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(59, 'L_AMYGDALA', 'NAD', 0, 'RADIO', NULL, 'Left side Amygdala', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(60, 'MR SESSIONS', 'NAD', 0, 'RADIO', NULL, 'Magnetic Resonance Session', NULL, NULL, 0, 5, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(61, 'PET SESSIONS', 'NAD', 0, 'RADIO', NULL, 'Positron Emission Tomography Session', NULL, NULL, 0, 5, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(62, 'CT SESSIONS', 'NAD', 0, 'RADIO', NULL, 'Computed Tomography Session', NULL, NULL, 0, 5, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(63, 'AMYLOID_PRESENC', 'NPD', 0, 'RADIO', NULL, 'amyloid_presence', NULL, NULL, 0, 1, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(64, 'R_CAUDATE', 'NPD', 0, 'RADIO', NULL, 'Right side Caudate', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(65, 'L_CAUDATE', 'NPD', 0, 'RADIO', NULL, 'Left side Caudate', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(66, 'R_PUTAMEN', 'NPD', 0, 'RADIO', NULL, 'Right side Putamen', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(67, 'L_PUTAMEN', 'NPD', 0, 'RADIO', NULL, 'Left side Putamen', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(68, 'R_THALAMUS', 'NPD', 0, 'RADIO', NULL, 'Right side Thalamus', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(69, 'L_THALAMUS', 'NPD', 0, 'RADIO', NULL, 'Left side Thalamus', NULL, NULL, 0, 2, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(70, 'MR SESSIONS', 'NPD', 0, 'RADIO', NULL, 'Magnetic Resonance Session', NULL, NULL, 0, 5, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(71, 'PET SESSIONS', 'NPD', 0, 'RADIO', NULL, 'Positron Emission Tomography Session', NULL, NULL, 0, 5, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11'),
	(72, 'CT SESSIONS', 'NPD', 0, 'RADIO', NULL, 'Computed Tomography Session', NULL, NULL, 0, 5, NULL, NULL, NULL, '2021-05-19 16:01:11', '2021-05-19 16:01:11');
/*!40000 ALTER TABLE `progettitest` ENABLE KEYS */;

-- Dump della struttura di tabella molim.progetto_test
CREATE TABLE IF NOT EXISTS `progetto_test` (
  `id_progetto` varchar(3) NOT NULL,
  `id_test` varchar(10) NOT NULL,
  KEY `progetto_test_id_progetto_fkey` (`id_progetto`),
  KEY `progetto_test_id_test_fkey` (`id_test`),
  CONSTRAINT `progetto_test_id_progetto_fkey` FOREIGN KEY (`id_progetto`) REFERENCES `progetti` (`id_progetto`),
  CONSTRAINT `progetto_test_id_test_fkey` FOREIGN KEY (`id_test`) REFERENCES `test_neurologici` (`id_test`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.progetto_test: ~43 rows (circa)
/*!40000 ALTER TABLE `progetto_test` DISABLE KEYS */;
INSERT INTO `progetto_test` (`id_progetto`, `id_test`) VALUES
	('NPD', 'TOKEN'),
	('NPD', 'COWAT'),
	('NPD', 'RAVLT_RI'),
	('NPD', 'RAVLT_RD'),
	('NPD', 'FCSRT_IFR'),
	('NPD', 'FCSRT_ITR'),
	('NPD', 'FCSRT_DFR'),
	('NPD', 'FCSRT_DTR'),
	('NPD', 'FCSRT_ISC'),
	('NPD', 'DIGIT_FW'),
	('NPD', 'DIGIT_BW'),
	('NPD', 'FAB'),
	('NPD', 'STROOP_W'),
	('NPD', 'STROOP_C'),
	('NPD', 'STROOP_CW'),
	('NPD', 'WEIGL'),
	('NPD', 'JLO_V'),
	('NPD', 'BECK_II'),
	('NPD', 'HAMA'),
	('NPD', 'UPDRS_I'),
	('NPD', 'UPDRS_II'),
	('NPD', 'UPDRS_III'),
	('NPD', 'UPDRS_IV'),
	('NPD', 'HeY'),
	('NPD', 'MMSE'),
	('NAD', 'TOKEN'),
	('NAD', 'COWAT'),
	('NAD', 'RAVLT_RI'),
	('NAD', 'RAVLT_RD'),
	('NAD', 'FCSRT_IFR'),
	('NAD', 'FCSRT_ITR'),
	('NAD', 'FCSRT_DFR'),
	('NAD', 'FCSRT_DTR'),
	('NAD', 'FCSRT_ISC'),
	('NAD', 'DIGIT_FW'),
	('NAD', 'DIGIT_BW'),
	('NAD', 'FAB'),
	('NAD', 'STROOP_W'),
	('NAD', 'STROOP_C'),
	('NAD', 'STROOP_CW'),
	('NAD', 'WEIGL'),
	('NAD', 'JLO_V'),
	('NAD', 'MMSE');
/*!40000 ALTER TABLE `progetto_test` ENABLE KEYS */;

-- Dump della struttura di tabella molim.risultati_indagini_radiomiche
CREATE TABLE IF NOT EXISTS `risultati_indagini_radiomiche` (
  `id_paziente` varchar(25) NOT NULL,
  `id_progetto` varchar(3) NOT NULL,
  `data` date NOT NULL,
  `amyloid_presence` varchar(10) DEFAULT NULL,
  `r_parietal` decimal(5,2) DEFAULT NULL,
  `l_parietal` decimal(5,2) DEFAULT NULL,
  `r_occipital` decimal(5,2) DEFAULT NULL,
  `l_occipital` decimal(5,2) DEFAULT NULL,
  `r_temporal` decimal(5,2) DEFAULT NULL,
  `l_temporal` decimal(5,2) DEFAULT NULL,
  `r_frontal` decimal(5,2) DEFAULT NULL,
  `l_frontal` decimal(5,2) DEFAULT NULL,
  `r_limbiccortex` decimal(5,2) DEFAULT NULL,
  `l_limbiccortex` decimal(5,2) DEFAULT NULL,
  `r_hippocampus` decimal(5,2) DEFAULT NULL,
  `l_hippocampus` decimal(5,2) DEFAULT NULL,
  `r_amygdala` decimal(5,2) DEFAULT NULL,
  `l_amygdala` decimal(5,2) DEFAULT NULL,
  `r_caudate` decimal(5,2) DEFAULT NULL,
  `l_caudate` decimal(5,2) DEFAULT NULL,
  `r_putamen` decimal(5,2) DEFAULT NULL,
  `l_putamen` decimal(5,2) DEFAULT NULL,
  `r_thalamus` decimal(5,2) DEFAULT NULL,
  `l_thalamus` decimal(5,2) DEFAULT NULL,
  `mr_sessions` decimal(5,2) DEFAULT NULL,
  `pet_sessions` decimal(5,2) DEFAULT NULL,
  `ct_sessions` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`id_paziente`,`id_progetto`,`data`),
  CONSTRAINT `risultati_indagini_radiomiche_id_paziente_id_progetto_fkey` FOREIGN KEY (`id_paziente`, `id_progetto`) REFERENCES `paziente` (`id_paziente`, `id_progetto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.risultati_indagini_radiomiche: ~41 rows (circa)
/*!40000 ALTER TABLE `risultati_indagini_radiomiche` DISABLE KEYS */;
INSERT INTO `risultati_indagini_radiomiche` (`id_paziente`, `id_progetto`, `data`, `amyloid_presence`, `r_parietal`, `l_parietal`, `r_occipital`, `l_occipital`, `r_temporal`, `l_temporal`, `r_frontal`, `l_frontal`, `r_limbiccortex`, `l_limbiccortex`, `r_hippocampus`, `l_hippocampus`, `r_amygdala`, `l_amygdala`, `r_caudate`, `l_caudate`, `r_putamen`, `l_putamen`, `r_thalamus`, `l_thalamus`, `mr_sessions`, `pet_sessions`, `ct_sessions`) VALUES
	('SDN_AMY_AD_005', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_007', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_008', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_009', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_010', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_011', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_012', 'NAD', '2021-04-20', 'negative', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_013', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_014', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_016', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_017', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_018', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_019', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_020', 'NAD', '2021-04-20', 'negative', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_025', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 2.00, 3.00, 1.00),
	('SDN_AMY_AD_028', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_034', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_054', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 1.00),
	('SDN_AMY_AD_073', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_078', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_080', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_081', 'NAD', '2021-04-20', 'negative', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 1.00),
	('SDN_AMY_AD_082', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00),
	('SDN_AMY_AD_088', 'NAD', '2021-04-20', 'positive', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_093', 'NAD', '2021-04-20', 'negative', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_094', 'NAD', '2021-04-20', 'negative', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_AMY_AD_099', 'NAD', '2021-04-20', 'negative', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_003', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 0.00),
	('SDN_FDG_AD_004', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 0.00),
	('SDN_FDG_AD_026', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_027', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 2.00, 3.00, 1.00),
	('SDN_FDG_AD_030', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_031', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_046', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_053', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 0.00),
	('SDN_FDG_AD_056', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_057', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 0.00),
	('SDN_FDG_AD_061', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 0.00),
	('SDN_FDG_AD_063', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 0.00),
	('SDN_FDG_AD_066', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_069', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_072', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_074', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_087', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_095', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 2.00, 1.00),
	('SDN_FDG_AD_098', 'NAD', '2021-04-20', '', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 1.00, 0.00);
/*!40000 ALTER TABLE `risultati_indagini_radiomiche` ENABLE KEYS */;

-- Dump della struttura di tabella molim.risultati_test_neurologici
CREATE TABLE IF NOT EXISTS `risultati_test_neurologici` (
  `id_paziente` varchar(25) NOT NULL,
  `id_progetto` varchar(3) NOT NULL,
  `data` date NOT NULL,
  `updrs_i` decimal(5,2) DEFAULT NULL,
  `updrs_ii` decimal(5,2) DEFAULT NULL,
  `updrs_iii` decimal(5,2) DEFAULT NULL,
  `updrs_iv` decimal(5,2) DEFAULT NULL,
  `hey` decimal(5,2) DEFAULT NULL,
  `mmse` decimal(5,2) DEFAULT NULL,
  `token` decimal(5,2) DEFAULT NULL,
  `cowat` decimal(5,2) DEFAULT NULL,
  `ravlt_ri` decimal(5,2) DEFAULT NULL,
  `ravlt_rd` decimal(5,2) DEFAULT NULL,
  `fcsrt_ifr` decimal(5,2) DEFAULT NULL,
  `fcsrt_itr` decimal(5,2) DEFAULT NULL,
  `fcsrt_dfr` decimal(5,2) DEFAULT NULL,
  `fcsrt_dtr` decimal(5,2) DEFAULT NULL,
  `fcsrt_isc` decimal(5,2) DEFAULT NULL,
  `digit_fw` decimal(5,2) DEFAULT NULL,
  `digit_bw` decimal(5,2) DEFAULT NULL,
  `fab` decimal(5,2) DEFAULT NULL,
  `stroop_w` decimal(5,2) DEFAULT NULL,
  `stroop_c` decimal(5,2) DEFAULT NULL,
  `stroop_cw` decimal(5,2) DEFAULT NULL,
  `weigl` decimal(5,2) DEFAULT NULL,
  `jlo_v` decimal(5,2) DEFAULT NULL,
  `beck_ii` decimal(5,2) DEFAULT NULL,
  `hama` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`id_paziente`,`id_progetto`,`data`),
  CONSTRAINT `risultati_test_id_paziente_id_progetto_fkey` FOREIGN KEY (`id_paziente`, `id_progetto`) REFERENCES `paziente` (`id_paziente`, `id_progetto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.risultati_test_neurologici: ~254 rows (circa)
/*!40000 ALTER TABLE `risultati_test_neurologici` DISABLE KEYS */;
INSERT INTO `risultati_test_neurologici` (`id_paziente`, `id_progetto`, `data`, `updrs_i`, `updrs_ii`, `updrs_iii`, `updrs_iv`, `hey`, `mmse`, `token`, `cowat`, `ravlt_ri`, `ravlt_rd`, `fcsrt_ifr`, `fcsrt_itr`, `fcsrt_dfr`, `fcsrt_dtr`, `fcsrt_isc`, `digit_fw`, `digit_bw`, `fab`, `stroop_w`, `stroop_c`, `stroop_cw`, `weigl`, `jlo_v`, `beck_ii`, `hama`) VALUES
	('SDN_AMY_AD_005', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_007', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_008', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_009', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_010', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_011', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_012', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_013', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_014', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_016', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_017', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_018', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_019', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_020', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_025', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_028', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_034', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_054', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_073', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_078', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_080', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_081', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_082', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_088', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_093', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_094', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_AD_099', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_001', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_015', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_051', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_052', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_055', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_064', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_075', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_076', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_077', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_079', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_AMY_PD_083', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 22.00, 13.00),
	('SDN_AMY_PD_096', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_003', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_004', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_026', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_027', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_030', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_031', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_046', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_053', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_056', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_057', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_061', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_063', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_066', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_069', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_072', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_074', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_087', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_095', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_AD_098', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_002', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 14.00),
	('SDN_FDG_PD_006', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 11.00, 5.00),
	('SDN_FDG_PD_021', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 20.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_022', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 6.00, 4.00),
	('SDN_FDG_PD_023', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 9.00, 4.00),
	('SDN_FDG_PD_024', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 5.00),
	('SDN_FDG_PD_029', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 18.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_032', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 18.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 17.00, 11.00),
	('SDN_FDG_PD_033', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 3.00, 1.00),
	('SDN_FDG_PD_035', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_036', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 13.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 20.00, 16.00),
	('SDN_FDG_PD_037', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_038', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 2.00, 2.00),
	('SDN_FDG_PD_039', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 5.00, 3.00),
	('SDN_FDG_PD_040', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_041', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 10.00, 8.00),
	('SDN_FDG_PD_042', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 22.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_043', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 23.00, 21.00),
	('SDN_FDG_PD_044', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 5.00),
	('SDN_FDG_PD_045', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 19.00),
	('SDN_FDG_PD_047', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 13.00, 9.00),
	('SDN_FDG_PD_048', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 0.00),
	('SDN_FDG_PD_049', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.00, 5.00),
	('SDN_FDG_PD_050', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 5.00, 3.00),
	('SDN_FDG_PD_058', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 37.00, 17.00),
	('SDN_FDG_PD_059', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 11.00, 9.00),
	('SDN_FDG_PD_060', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 13.00, 5.00),
	('SDN_FDG_PD_062', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 16.00, 13.00),
	('SDN_FDG_PD_065', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 6.00, 10.00),
	('SDN_FDG_PD_067', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 10.00, 3.00),
	('SDN_FDG_PD_068', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_070', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_071', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_084', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 11.00, 9.00),
	('SDN_FDG_PD_086', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 17.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_089', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 23.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 21.00),
	('SDN_FDG_PD_090', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 14.00, 10.00),
	('SDN_FDG_PD_091', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 6.00, 7.00),
	('SDN_FDG_PD_092', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 11.00, 11.00),
	('SDN_FDG_PD_097', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('SDN_FDG_PD_100', 'NPD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 18.00, 8.00),
	('UNICZ_FDG_AD_001', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 30.00, 26.00, 23.00, 0.00, 26.00, 34.00, 10.00, 2.00, 0.80, 4.00, 2.00, 15.00, 21.00, 28.00, 68.00, 10.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_AD_002', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 17.00, 25.00, 16.00, 12.00, 0.00, 12.00, 36.00, 6.00, 8.00, 1.00, 4.00, 2.00, 12.00, 23.00, 27.00, 68.00, 10.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_003', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 20.00, 23.50, 17.00, 23.00, 1.00, 3.00, 35.00, 6.00, 12.00, 0.52, 4.00, 2.00, 12.00, 21.00, 28.00, 68.00, 7.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_004', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 21.00, 27.00, 26.00, 12.00, 0.00, 14.00, 18.00, 3.00, 8.00, 0.95, 4.00, 2.00, 11.00, 23.00, 27.00, 71.00, 7.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_AD_005', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 16.00, 23.00, 17.00, 12.00, 1.00, 26.00, 24.00, 0.00, 6.00, 625.00, 4.00, 2.00, 12.00, 16.00, 26.00, 71.00, 10.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_006', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 21.00, 25.00, 21.00, 23.00, 0.00, 3.00, 18.00, 3.00, 12.00, 0.95, 5.00, 2.00, 12.00, 16.00, 26.00, 60.00, 4.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_007', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 22.00, 28.00, 26.00, 17.00, 0.00, 12.00, 28.00, 3.00, 9.00, 0.67, 4.00, 3.00, 11.00, 14.00, 24.00, 60.00, 7.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_AD_008', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 23.00, 19.00, 10.00, 23.00, 0.00, 17.00, 35.00, 1.00, 6.00, 0.52, 4.00, 3.00, 12.00, 16.00, 29.00, 82.00, 7.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_AD_009', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 19.00, 23.50, 6.00, 16.00, 1.00, 3.00, 18.00, 10.00, 6.00, 0.95, 4.00, 2.00, 15.00, 23.00, 29.00, 68.00, 7.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_010', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 29.00, 17.00, 18.00, 0.00, 17.00, 35.00, 6.00, 10.00, 1.00, 4.00, 4.00, 6.00, 21.00, 26.00, 68.00, 4.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_011', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 16.00, 27.00, 26.00, 23.00, 1.00, 14.00, 18.00, 10.00, 12.00, 0.45, 4.00, 2.00, 11.00, 20.00, 27.00, 60.00, 13.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_012', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 23.00, 23.50, 13.00, 35.00, 1.00, 12.00, 35.00, 6.00, 8.00, 0.52, 4.00, 2.00, 14.00, 16.00, 25.00, 71.00, 10.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_013', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 16.00, 25.00, 26.00, 23.00, 0.00, 14.00, 26.00, 1.00, 8.00, 625.00, 4.00, 4.00, 15.00, 16.00, 26.00, 68.00, 3.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_014', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 15.00, 27.00, 17.00, 23.00, 0.00, 12.00, 35.00, 3.00, 12.00, 0.45, 5.00, 2.00, 12.00, 21.00, 29.00, 71.00, 7.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_015', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 27.00, 25.00, 16.00, 0.00, 3.00, 26.00, 1.00, 6.00, 0.45, 4.00, 2.00, 14.00, 23.00, 25.00, 82.00, 3.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_016', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 17.00, 25.00, 13.00, 35.00, 0.00, 14.00, 35.00, 6.00, 6.00, 625.00, 5.00, 4.00, 14.00, 16.00, 27.00, 60.00, 3.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_017', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 17.00, 30.00, 4.00, 23.00, 1.00, 12.00, 36.00, 3.00, 8.00, 625.00, 4.00, 2.00, 11.00, 23.00, 24.00, 60.00, 7.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_018', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 17.00, 23.50, 13.00, 17.00, 0.00, 17.00, 26.00, 6.00, 6.00, 0.75, 4.00, 2.00, 12.00, 20.00, 27.00, 68.00, 7.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_019', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 22.00, 30.00, 12.00, 17.00, 1.00, 17.00, 35.00, 6.00, 12.00, 625.00, 4.00, 3.00, 6.00, 23.00, 29.00, 56.00, 7.00, 16.00, 0.00, 0.00),
	('UNICZ_FDG_AD_020', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 16.00, 27.00, 13.00, 17.00, 1.00, 3.00, 26.00, 3.00, 8.00, 0.75, 4.00, 2.00, 12.00, 21.00, 26.00, 71.00, 3.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_021', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 20.50, 18.00, 12.00, 4.00, 17.00, 18.00, 3.00, 8.00, 0.75, 4.00, 2.00, 15.00, 23.00, 27.00, 60.00, 7.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_022', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 12.00, 25.00, 26.00, 23.00, 0.00, 26.00, 34.00, 10.00, 2.00, 0.80, 4.00, 2.00, 15.00, 21.00, 28.00, 68.00, 10.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_AD_023', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 12.00, 27.00, 17.00, 17.00, 0.00, 14.00, 36.00, 3.00, 6.00, 625.00, 4.00, 3.00, 12.00, 23.00, 29.00, 56.00, 3.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_024', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 22.00, 28.00, 16.00, 12.00, 0.00, 3.00, 21.00, 0.00, 8.00, 0.54, 4.00, 2.00, 15.00, 23.00, 26.00, 60.00, 5.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_025', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 19.00, 25.00, 17.00, 35.00, 0.00, 14.00, 35.00, 10.00, 12.00, 0.95, 5.00, 3.00, 12.00, 21.00, 29.00, 71.00, 3.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_026', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 29.00, 14.00, 35.00, 4.00, 22.00, 36.00, 8.00, 12.00, 1.00, 5.00, 4.00, 14.00, 16.00, 26.00, 71.00, 13.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_027', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 30.00, 13.00, 33.00, 3.00, 24.00, 36.00, 7.00, 12.00, 1.00, 4.00, 3.00, 14.00, 17.00, 25.00, 56.00, 4.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_028', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 15.00, 25.00, 17.00, 22.00, 1.00, 3.00, 16.00, 5.00, 6.00, 0.75, 4.00, 4.00, 6.00, 20.00, 25.00, 71.00, 3.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_029', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 30.00, 17.00, 22.00, 3.00, 3.00, 36.00, 3.00, 8.00, 0.95, 5.00, 2.00, 15.00, 16.00, 29.00, 68.00, 7.00, 16.00, 0.00, 0.00),
	('UNICZ_FDG_AD_030', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 25.00, 26.00, 17.00, 1.00, 3.00, 19.00, 3.00, 12.00, 625.00, 4.00, 3.00, 12.00, 23.00, 28.00, 68.00, 3.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_031', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 26.00, 26.00, 27.00, 0.00, 15.00, 26.00, 2.00, 9.00, 0.52, 4.00, 3.00, 15.00, 20.00, 29.00, 64.00, 7.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_AD_032', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 26.00, 19.00, 12.00, 0.00, 4.00, 19.00, 0.00, 6.00, 0.47, 4.00, 3.00, 9.00, 16.00, 27.00, 82.00, 7.00, 16.00, 0.00, 0.00),
	('UNICZ_FDG_AD_033', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 30.00, 20.00, 16.00, 1.00, 19.00, 36.00, 5.00, 12.00, 1.00, 4.00, 2.00, 8.00, 22.00, 26.00, 74.00, 2.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_AD_034', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 20.00, 25.00, 16.00, 22.00, 1.00, 3.00, 16.00, 1.00, 3.00, 0.39, 4.00, 4.00, 15.00, 16.00, 24.00, 71.00, 3.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_AD_035', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 20.00, 27.00, 17.00, 22.00, 1.00, 18.00, 35.00, 6.00, 10.00, 0.39, 4.00, 4.00, 12.00, 23.00, 27.00, 60.00, 3.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_AD_036', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 30.00, 13.00, 23.00, 1.00, 17.00, 16.00, 1.00, 12.00, 0.75, 5.00, 3.00, 15.00, 16.00, 26.00, 68.00, 7.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_037', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 20.50, 13.00, 12.00, 0.00, 20.00, 32.00, 6.00, 11.00, 0.75, 4.00, 2.00, 15.00, 23.00, 26.00, 60.00, 3.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_AD_038', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 19.00, 26.00, 13.00, 16.00, 1.00, 17.00, 19.00, 1.00, 12.00, 0.75, 5.00, 3.00, 12.00, 16.00, 26.00, 71.00, 7.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_AD_039', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 20.00, 23.50, 17.00, 22.00, 0.00, 17.00, 36.00, 10.00, 8.00, 0.52, 4.00, 3.00, 15.00, 23.00, 27.00, 68.00, 3.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_040', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 27.00, 13.00, 16.00, 0.00, 17.00, 36.00, 3.00, 11.00, 0.95, 4.00, 3.00, 12.00, 16.00, 27.00, 68.00, 7.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_AD_041', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 27.00, 25.00, 23.00, 4.00, 3.00, 35.00, 5.00, 11.00, 0.75, 4.00, 4.00, 15.00, 16.00, 25.00, 71.00, 7.00, 16.00, 0.00, 0.00),
	('UNICZ_FDG_AD_042', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 18.00, 23.00, 0.00, 16.00, 0.00, 17.00, 19.00, 1.00, 6.00, 0.75, 4.00, 2.00, 15.00, 23.00, 27.00, 60.00, 3.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_AD_043', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 21.00, 27.00, 17.00, 23.00, 1.00, 24.00, 35.00, 3.00, 8.00, 0.95, 4.00, 3.00, 12.00, 16.00, 29.00, 68.00, 7.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_001', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 18.00, 25.00, 5.00, 28.00, 7.00, 23.00, 36.00, 8.00, 11.00, 1.00, 4.00, 2.00, 9.00, 23.00, 22.00, 32.00, 1.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_002', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 32.50, 23.00, 34.00, 4.00, 22.00, 35.00, 7.00, 12.00, 0.93, 4.00, 3.00, 17.00, 16.00, 21.00, 42.00, 10.00, 18.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_003', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 29.50, 52.00, 32.00, 5.00, 23.00, 36.00, 7.00, 12.00, 1.00, 5.00, 3.00, 15.00, 17.00, 28.00, 56.00, 4.00, 11.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_004', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 34.00, 35.00, 47.00, 6.00, 27.00, 36.00, 11.00, 12.00, 1.00, 6.00, 4.00, 17.00, 17.00, 17.00, 32.00, 12.00, 23.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_005', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 32.00, 25.00, 38.00, 6.00, 21.00, 36.00, 7.00, 12.00, 1.00, 4.00, 3.00, 17.00, 20.00, 29.00, 59.00, 10.00, 23.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_006', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 34.00, 29.00, 42.00, 8.00, 30.00, 36.00, 9.00, 12.00, 1.00, 4.00, 3.00, 15.00, 18.00, 22.00, 45.00, 13.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_007', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 34.50, 39.00, 27.00, 4.00, 29.00, 36.00, 10.00, 12.00, 1.00, 4.00, 3.00, 16.00, 13.00, 20.00, 25.00, 13.00, 21.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_008', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 29.00, 16.00, 31.00, 2.00, 19.00, 36.00, 6.00, 12.00, 1.00, 3.00, 2.00, 14.00, 22.00, 27.00, 66.00, 12.00, 23.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_009', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 33.00, 42.00, 56.00, 12.00, 27.00, 36.00, 11.00, 11.00, 1.00, 6.00, 4.00, 17.00, 21.00, 20.00, 35.00, 12.00, 28.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_010', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 36.00, 23.00, 32.00, 5.00, 24.00, 36.00, 10.00, 12.00, 1.00, 5.00, 3.00, 16.00, 16.00, 18.00, 38.00, 10.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_011', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 25.00, 11.00, 37.00, 3.00, 24.00, 36.00, 4.00, 12.00, 1.00, 4.00, 3.00, 12.00, 16.00, 21.00, 76.00, 4.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_012', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 29.50, 14.00, 36.00, 7.00, 23.00, 36.00, 9.00, 12.00, 1.00, 4.00, 3.00, 8.00, 15.00, 24.00, 50.00, 9.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_013', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 22.00, 31.50, 9.00, 11.00, 2.00, 20.00, 36.00, 9.00, 12.00, 1.00, 5.00, 2.00, 12.00, 21.00, 28.00, 49.00, 4.00, 13.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_014', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 33.00, 37.00, 37.00, 7.00, 20.00, 36.00, 7.00, 12.00, 1.00, 4.00, 2.00, 17.00, 15.00, 31.00, 50.00, 10.00, 15.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_015', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 34.00, 45.00, 45.00, 10.00, 27.00, 36.00, 10.00, 12.00, 1.00, 4.00, 3.00, 18.00, 19.00, 24.00, 37.00, 15.00, 21.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_016', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 32.00, 23.00, 32.00, 3.00, 21.00, 36.00, 7.00, 12.00, 1.00, 5.00, 4.00, 17.00, 23.00, 22.00, 97.00, 9.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_017', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 34.00, 17.00, 32.00, 6.00, 21.00, 36.00, 9.00, 12.00, 1.00, 4.00, 2.00, 13.00, 15.00, 31.00, 50.00, 4.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_018', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 22.00, 25.00, 6.00, 25.00, 1.00, 25.00, 35.00, 6.00, 11.00, 0.91, 5.00, 4.00, 7.00, 23.00, 24.00, 50.00, 9.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_019', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 32.00, 29.00, 30.00, 2.00, 24.00, 36.00, 5.00, 12.00, 1.00, 6.00, 4.00, 17.00, 15.00, 19.00, 32.00, 9.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_020', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 34.00, 33.00, 36.00, 8.00, 33.00, 36.00, 10.00, 12.00, 1.00, 4.00, 3.00, 16.00, 12.00, 20.00, 37.00, 13.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_021', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 26.50, 22.00, 35.00, 6.00, 23.00, 36.00, 6.00, 12.00, 1.00, 4.00, 3.00, 16.00, 16.00, 26.00, 54.00, 9.00, 15.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_022', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 25.00, 11.00, 19.00, 0.00, 18.00, 33.00, 8.00, 12.00, 0.83, 4.00, 2.00, 17.00, 15.00, 24.00, 61.00, 9.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_023', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 32.00, 11.00, 41.00, 6.00, 24.00, 36.00, 7.00, 12.00, 1.00, 5.00, 2.00, 16.00, 12.00, 22.00, 50.00, 9.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_024', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 34.00, 45.00, 54.00, 9.00, 32.00, 36.00, 10.00, 12.00, 1.00, 6.00, 4.00, 18.00, 16.00, 14.00, 31.00, 12.00, 24.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_025', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 20.00, 26.00, 19.00, 30.00, 3.00, 16.00, 35.00, 5.00, 12.00, 0.95, 5.00, 4.00, 17.00, 23.00, 25.00, 31.00, 9.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_026', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 33.50, 33.00, 42.00, 5.00, 28.00, 36.00, 4.00, 12.00, 1.00, 5.00, 3.00, 16.00, 17.00, 19.00, 52.00, 9.00, 18.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_027', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 34.00, 23.00, 32.00, 3.00, 21.00, 36.00, 7.00, 12.00, 1.00, 4.00, 2.00, 17.00, 23.00, 22.00, 52.00, 12.00, 18.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_028', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 32.00, 23.00, 52.00, 5.00, 21.00, 36.00, 7.00, 12.00, 0.95, 4.00, 2.00, 18.00, 17.00, 25.00, 50.00, 9.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_029', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 34.00, 52.00, 52.00, 6.00, 26.00, 36.00, 9.00, 11.00, 1.00, 6.00, 3.00, 16.00, 15.00, 17.00, 29.00, 4.00, 25.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_030', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 17.00, 23.50, 23.00, 32.00, 3.00, 21.00, 36.00, 7.00, 11.00, 0.95, 4.00, 3.00, 14.00, 17.00, 31.00, 50.00, 9.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_031', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 30.50, 21.00, 29.00, 8.00, 25.00, 35.00, 8.00, 12.00, 0.91, 5.00, 3.00, 12.00, 16.00, 25.00, 52.00, 5.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_032', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 29.00, 25.00, 21.00, 2.00, 13.00, 35.00, 4.00, 12.00, 0.95, 5.00, 3.00, 14.00, 15.00, 20.00, 32.00, 9.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_033', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 32.50, 14.00, 27.00, 1.00, 20.00, 36.00, 5.00, 12.00, 1.00, 4.00, 3.00, 12.00, 15.00, 17.00, 37.00, 7.00, 18.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_034', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 23.00, 29.00, 23.00, 32.00, 3.00, 21.00, 36.00, 7.00, 11.00, 0.95, 5.00, 3.00, 12.00, 10.00, 25.00, 32.00, 12.00, 17.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_035', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 30.00, 23.00, 26.00, 5.00, 15.00, 36.00, 8.00, 12.00, 1.00, 4.00, 4.00, 14.00, 17.00, 22.00, 50.00, 4.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_036', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 29.00, 9.00, 31.00, 3.00, 12.00, 34.00, 1.00, 12.00, 0.92, 4.00, 4.00, 7.00, 16.00, 27.00, 97.00, 7.00, 19.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_037', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 32.00, 14.00, 32.00, 5.00, 21.00, 35.00, 7.00, 11.00, 0.95, 5.00, 3.00, 14.00, 23.00, 22.00, 50.00, 12.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_038', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 31.50, 12.00, 25.00, 4.00, 28.00, 36.00, 7.00, 12.00, 1.00, 4.00, 3.00, 14.00, 23.00, 24.00, 53.00, 7.00, 14.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_039', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 31.00, 25.00, 18.00, 0.00, 21.00, 34.00, 4.00, 10.00, 0.87, 4.00, 4.00, 15.00, 18.00, 22.00, 59.00, 8.00, 25.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_040', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 28.00, 32.00, 19.00, 23.00, 0.00, 17.00, 36.00, 7.00, 12.00, 1.00, 5.00, 4.00, 17.00, 13.00, 20.00, 36.00, 9.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_041', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 25.00, 25.00, 26.00, 3.00, 21.00, 35.00, 7.00, 11.00, 0.95, 5.00, 3.00, 14.00, 10.00, 20.00, 97.00, 12.00, 23.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_042', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 26.00, 30.00, 14.00, 25.00, 7.00, 28.00, 36.00, 8.00, 12.00, 1.00, 4.00, 3.00, 14.00, 10.00, 19.00, 31.00, 4.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_043', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 23.00, 30.00, 24.00, 26.00, 3.00, 12.00, 30.00, 3.00, 11.00, 0.75, 5.00, 3.00, 14.00, 15.00, 24.00, 61.00, 8.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_044', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 31.00, 18.00, 50.00, 13.00, 29.00, 6.00, 9.00, 12.00, 1.00, 4.00, 3.00, 14.00, 12.00, 19.00, 54.00, 12.00, 26.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_045', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 25.00, 12.00, 36.00, 7.00, 15.00, 31.00, 7.00, 11.00, 0.76, 3.00, 2.00, 8.00, 21.00, 19.00, 32.00, 4.00, 23.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_046', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 29.00, 30.00, 31.00, 44.00, 10.00, 28.00, 36.00, 10.00, 12.00, 1.00, 5.00, 3.00, 18.00, 18.00, 23.00, 67.00, 12.00, 16.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_047', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 25.00, 23.50, 16.00, 13.00, 0.00, 1.00, 20.00, 1.00, 8.00, 0.95, 4.00, 2.00, 12.00, 17.00, 22.00, 61.00, 6.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_048', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 30.00, 34.00, 24.00, 25.00, 4.00, 27.00, 26.00, 11.00, 12.00, 1.00, 4.00, 4.00, 16.00, 21.00, 31.00, 97.00, 11.00, 20.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_049', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 29.00, 15.00, 21.00, 0.00, 11.00, 24.00, 0.00, 6.00, 0.52, 4.00, 4.00, 14.00, 21.00, 36.00, 61.00, 12.00, 23.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_050', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 24.00, 34.00, 28.00, 16.00, 0.00, 10.00, 21.00, 0.00, 6.00, 0.42, 5.00, 3.00, 14.00, 16.00, 21.00, 68.00, 9.00, 23.00, 0.00, 0.00),
	('UNICZ_FDG_CTRL_051', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 27.00, 34.00, 14.00, 25.00, 7.00, 21.00, 35.00, 7.00, 11.00, 0.95, 4.00, 3.00, 14.00, 17.00, 25.00, 32.00, 12.00, 20.00, 0.00, 0.00),
	('UNICZ_FDOPA_CTRL_001', 'NPD', '2021-04-20', 0.00, 2.00, 4.00, 0.00, 0.00, 28.00, 33.00, 27.00, 41.00, 7.00, 34.00, 36.00, 12.00, 12.00, 1.00, 4.00, 3.00, 18.00, 11.00, 18.00, 33.00, 5.00, 23.00, 14.00, 14.00),
	('UNICZ_FDOPA_CTRL_002', 'NPD', '2021-04-20', 2.00, 2.00, 6.00, 0.00, 0.00, 28.00, 25.50, 20.00, 33.00, 5.00, 13.00, 36.00, 6.00, 11.00, 1.00, 5.00, 4.00, 18.00, 13.00, 19.00, 33.00, 5.00, 24.00, 3.00, 9.00),
	('UNICZ_FDOPA_CTRL_003', 'NPD', '2021-04-20', 2.00, 2.00, 6.00, 0.00, 0.00, 29.00, 33.50, 20.00, 45.00, 2.00, 27.00, 26.00, 12.00, 12.00, 1.00, 5.00, 4.00, 17.00, 13.00, 18.00, 22.00, 9.00, 24.00, 2.00, 3.00),
	('UNICZ_FDOPA_CTRL_004', 'NPD', '2021-04-20', 1.00, 3.00, 7.00, 0.00, 0.00, 28.00, 33.00, 20.00, 33.00, 5.00, 25.00, 26.00, 8.00, 12.00, 1.00, 5.00, 2.00, 17.00, 11.00, 19.00, 32.00, 5.00, 15.00, 13.00, 3.00),
	('UNICZ_FDOPA_CTRL_005', 'NPD', '2021-04-20', 2.00, 1.00, 6.00, 0.00, 0.00, 29.00, 25.50, 20.00, 33.00, 11.00, 34.00, 36.00, 9.00, 12.00, 1.00, 4.00, 4.00, 12.00, 13.00, 18.00, 32.00, 5.00, 14.00, 13.00, 11.00),
	('UNICZ_FDOPA_CTRL_006', 'NPD', '2021-04-20', 4.00, 8.00, 30.00, 0.00, 0.00, 20.00, 27.00, 8.00, 33.00, 5.00, 22.00, 36.00, 6.00, 11.00, 1.00, 5.00, 2.00, 11.00, 11.00, 18.00, 32.00, 5.00, 24.00, 2.00, 9.00),
	('UNICZ_FDOPA_CTRL_007', 'NPD', '2021-04-20', 2.00, 3.00, 4.00, 0.00, 0.00, 30.00, 33.00, 37.00, 51.00, 11.00, 25.00, 36.00, 9.00, 12.00, 1.00, 5.00, 3.00, 16.00, 11.00, 18.00, 32.00, 12.00, 15.00, 3.00, 10.00),
	('UNICZ_FDOPA_CTRL_008', 'NPD', '2021-04-20', 2.00, 4.00, 10.00, 0.00, 0.00, 28.00, 25.50, 8.00, 33.00, 1.00, 13.00, 36.00, 8.00, 12.00, 1.00, 5.00, 4.00, 12.00, 11.00, 18.00, 22.00, 1.00, 14.00, 7.00, 5.00),
	('UNICZ_FDOPA_CTRL_009', 'NPD', '2021-04-20', 1.00, 2.00, 6.00, 0.00, 0.00, 29.00, 26.00, 20.00, 45.00, 2.00, 25.00, 36.00, 6.00, 11.00, 1.00, 5.00, 2.00, 12.00, 11.00, 18.00, 32.00, 9.00, 15.00, 3.00, 9.00),
	('UNICZ_FDOPA_CTRL_010', 'NPD', '2021-04-20', 2.00, 2.00, 10.00, 0.00, 0.00, 28.00, 29.00, 20.00, 41.00, 5.00, 22.00, 36.00, 12.00, 12.00, 1.00, 5.00, 4.00, 14.00, 13.00, 19.00, 22.00, 9.00, 24.00, 13.00, 5.00),
	('UNICZ_FDOPA_CTRL_011', 'NPD', '2021-04-20', 1.00, 4.00, 10.00, 0.00, 0.00, 29.00, 33.00, 37.00, 51.00, 5.00, 27.00, 36.00, 12.00, 12.00, 1.00, 5.00, 3.00, 17.00, 11.00, 18.00, 32.00, 12.00, 15.00, 7.00, 5.00),
	('UNICZ_FDOPA_CTRL_012', 'NPD', '2021-04-20', 0.00, 4.00, 10.00, 0.00, 0.00, 28.00, 26.00, 20.00, 22.00, 2.00, 25.00, 26.00, 12.00, 11.00, 1.00, 5.00, 4.00, 14.00, 11.00, 18.00, 22.00, 12.00, 14.00, 13.00, 9.00),
	('UNICZ_FDOPA_CTRL_013', 'NPD', '2021-04-20', 4.00, 4.00, 12.00, 0.00, 0.00, 29.00, 33.00, 8.00, 41.00, 5.00, 22.00, 36.00, 9.00, 12.00, 1.00, 4.00, 3.00, 14.00, 11.00, 19.00, 32.00, 9.00, 23.00, 7.00, 9.00),
	('UNICZ_FDOPA_CTRL_014', 'NPD', '2021-04-20', 0.00, 2.00, 5.00, 0.00, 0.00, 30.00, 25.50, 8.00, 22.00, 11.00, 22.00, 36.00, 12.00, 11.00, 1.00, 5.00, 4.00, 14.00, 13.00, 19.00, 32.00, 12.00, 24.00, 3.00, 5.00),
	('UNICZ_FDOPA_PD_001', 'NPD', '2021-04-20', 2.00, 4.00, 10.00, 0.00, 1.00, 27.00, 32.00, 28.00, 28.00, 4.00, 27.00, 36.00, 8.00, 12.00, 1.00, 6.00, 4.00, 18.00, 16.00, 21.00, 22.00, 10.00, 28.00, 12.00, 15.00),
	('UNICZ_FDOPA_PD_002', 'NPD', '2021-04-20', 2.00, 6.00, 10.00, 0.00, 1.50, 28.00, 32.00, 24.00, 39.00, 6.00, 25.00, 36.00, 8.00, 11.00, 1.00, 5.00, 4.00, 18.00, 17.00, 19.00, 22.00, 10.00, 21.00, 15.00, 15.00),
	('UNICZ_FDOPA_PD_003', 'NPD', '2021-04-20', 4.00, 4.00, 18.00, 2.00, 2.00, 29.00, 32.00, 25.00, 36.00, 9.00, 24.00, 36.00, 7.00, 12.00, 1.00, 4.00, 4.00, 17.00, 20.00, 24.00, 49.00, 12.00, 23.00, 15.00, 13.00),
	('UNICZ_FDOPA_PD_004', 'NPD', '2021-04-20', 3.00, 5.00, 10.00, 0.00, 2.00, 28.00, 34.00, 30.00, 28.00, 9.00, 25.00, 36.00, 7.00, 11.00, 1.00, 6.00, 4.00, 16.00, 20.00, 26.00, 34.00, 12.00, 21.00, 12.00, 12.00),
	('UNICZ_FDOPA_PD_005', 'NPD', '2021-04-20', 6.00, 10.00, 28.00, 4.00, 2.00, 29.00, 33.00, 17.00, 36.00, 2.00, 29.00, 36.00, 9.00, 12.00, 1.00, 5.00, 2.00, 17.00, 17.00, 19.00, 47.00, 9.00, 21.00, 15.00, 15.00),
	('UNICZ_FDOPA_PD_006', 'NPD', '2021-04-20', 4.00, 8.00, 33.00, 5.00, 3.00, 29.00, 33.00, 29.00, 39.00, 4.00, 24.00, 36.00, 8.00, 12.00, 1.00, 5.00, 4.00, 15.00, 17.00, 21.00, 37.00, 10.00, 18.00, 12.00, 20.00),
	('UNICZ_FDOPA_PD_007', 'NPD', '2021-04-20', 6.00, 6.00, 17.00, 0.00, 2.00, 27.00, 34.00, 30.00, 28.00, 9.00, 29.00, 36.00, 8.00, 11.00, 1.00, 5.00, 2.00, 15.00, 13.00, 19.00, 47.00, 9.00, 18.00, 10.00, 11.00),
	('UNICZ_FDOPA_PD_008', 'NPD', '2021-04-20', 3.00, 6.00, 15.00, 2.00, 1.50, 27.00, 32.00, 24.00, 36.00, 2.00, 27.00, 36.00, 8.00, 12.00, 1.00, 4.00, 4.00, 16.00, 20.00, 24.00, 22.00, 15.00, 21.00, 18.00, 20.00),
	('UNICZ_FDOPA_PD_009', 'NPD', '2021-04-20', 4.00, 2.00, 5.00, 0.00, 1.50, 27.00, 32.00, 27.00, 39.00, 6.00, 27.00, 36.00, 7.00, 12.00, 1.00, 4.00, 3.00, 17.00, 17.00, 21.00, 47.00, 8.00, 23.00, 10.00, 13.00),
	('UNICZ_FDOPA_PD_010', 'NPD', '2021-04-20', 4.00, 2.00, 15.00, 2.00, 2.00, 29.00, 33.00, 26.00, 42.00, 6.00, 26.00, 35.00, 9.00, 12.00, 0.90, 6.00, 3.00, 17.00, 14.00, 24.00, 26.00, 10.00, 14.00, 10.00, 18.00),
	('UNICZ_FDOPA_PD_011', 'NPD', '2021-04-20', 2.00, 4.00, 8.00, 0.00, 2.00, 27.00, 34.00, 21.00, 36.00, 2.00, 29.00, 36.00, 10.00, 11.00, 1.00, 4.00, 2.00, 16.00, 14.00, 21.00, 34.00, 9.00, 14.00, 7.00, 15.00),
	('UNICZ_FDOPA_PD_012', 'NPD', '2021-04-20', 6.00, 8.00, 20.00, 6.00, 3.00, 27.00, 31.50, 13.00, 27.00, 4.00, 25.00, 36.00, 7.00, 12.00, 1.00, 5.00, 3.00, 15.00, 11.00, 19.00, 24.50, 5.00, 21.00, 7.00, 10.00),
	('UNICZ_FDOPA_PD_013', 'NPD', '2021-04-20', 2.00, 4.00, 4.00, 0.00, 1.50, 28.00, 32.50, 33.00, 46.00, 10.00, 30.00, 36.00, 10.00, 12.00, 1.00, 4.00, 3.00, 18.00, 13.00, 18.00, 34.00, 15.00, 17.00, 12.00, 14.00),
	('UNICZ_FDOPA_PD_014', 'NPD', '2021-04-20', 2.00, 4.00, 11.00, 2.00, 2.00, 27.00, 33.00, 24.00, 42.00, 9.00, 27.00, 36.00, 9.00, 12.00, 1.00, 6.00, 2.00, 17.00, 13.00, 24.00, 26.00, 8.00, 23.00, 12.00, 12.00),
	('UNICZ_FDOPA_PD_015', 'NPD', '2021-04-20', 4.00, 4.00, 28.00, 2.00, 1.50, 28.00, 33.00, 17.00, 28.00, 4.00, 25.00, 36.00, 8.00, 12.00, 0.90, 5.00, 3.00, 15.00, 10.00, 21.00, 34.00, 15.00, 21.00, 10.00, 15.00),
	('UNICZ_FDOPA_PD_016', 'NPD', '2021-04-20', 2.00, 3.00, 15.00, 0.00, 1.00, 27.00, 32.00, 30.00, 42.00, 4.00, 27.00, 36.00, 10.00, 12.00, 1.00, 6.00, 3.00, 18.00, 14.00, 26.00, 26.00, 9.00, 21.00, 15.00, 12.00),
	('UNICZ_FDOPA_PD_017', 'NPD', '2021-04-20', 4.00, 6.00, 46.00, 4.00, 2.00, 27.00, 32.00, 24.00, 28.00, 10.00, 27.00, 36.00, 10.00, 11.00, 1.00, 6.00, 4.00, 18.00, 17.00, 24.00, 31.00, 12.00, 23.00, 18.00, 14.00),
	('UNICZ_FDOPA_PD_018', 'NPD', '2021-04-20', 4.00, 6.00, 12.00, 0.00, 2.00, 29.00, 33.00, 25.00, 41.00, 7.00, 29.00, 36.00, 12.00, 12.00, 1.00, 6.00, 2.00, 18.00, 11.00, 21.00, 31.00, 12.00, 23.00, 10.00, 11.00),
	('UNICZ_FDOPA_PD_019', 'NPD', '2021-04-20', 4.00, 4.00, 10.00, 0.00, 2.00, 29.00, 34.00, 30.00, 42.00, 7.00, 27.00, 36.00, 7.00, 12.00, 1.00, 4.00, 3.00, 18.00, 13.00, 26.00, 26.00, 9.00, 25.00, 18.00, 13.00),
	('UNICZ_FDOPA_PD_020', 'NPD', '2021-04-20', 4.00, 3.00, 5.00, 4.00, 2.00, 27.00, 32.00, 24.00, 42.00, 4.00, 29.00, 36.00, 10.00, 12.00, 1.00, 4.00, 4.00, 16.00, 20.00, 21.00, 34.00, 8.00, 17.00, 12.00, 18.00),
	('UNICZ_FDOPA_PD_021', 'NPD', '2021-04-20', 2.00, 2.00, 4.00, 0.00, 2.00, 28.00, 31.00, 24.00, 39.00, 4.00, 27.00, 36.00, 7.00, 12.00, 0.90, 5.00, 4.00, 15.00, 10.00, 19.00, 47.00, 9.00, 17.00, 10.00, 13.00),
	('UNICZ_FDOPA_PD_022', 'NPD', '2021-04-20', 3.00, 3.00, 8.00, 0.00, 1.50, 27.00, 32.00, 17.00, 42.00, 10.00, 25.00, 36.00, 11.00, 12.00, 1.00, 4.00, 3.00, 17.00, 13.00, 24.00, 34.00, 8.00, 21.00, 15.00, 14.00),
	('UNICZ_FDOPA_PD_023', 'NPD', '2021-04-20', 4.00, 6.00, 23.00, 0.00, 1.00, 27.00, 30.00, 17.00, 22.00, 7.00, 25.00, 36.00, 8.00, 12.00, 1.00, 4.00, 4.00, 17.00, 16.00, 26.00, 47.00, 8.00, 23.00, 22.00, 18.00),
	('UNICZ_FDOPA_PD_024', 'NPD', '2021-04-20', 2.00, 2.00, 8.00, 0.00, 1.00, 26.00, 34.00, 21.00, 39.00, 7.00, 33.00, 36.00, 11.00, 11.00, 1.00, 5.00, 3.00, 16.00, 16.00, 24.00, 37.00, 12.00, 15.00, 10.00, 15.00),
	('UNIME_AMY_AD_014', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_015', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_016', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_017', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_018', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_019', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_020', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_021', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_022', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_AMY_AD_023', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_001', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_002', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_003', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_004', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_005', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_006', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_007', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_008', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_009', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_010', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_011', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_012', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00),
	('UNIME_FDG_AD_013', 'NAD', '2021-04-20', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00);
/*!40000 ALTER TABLE `risultati_test_neurologici` ENABLE KEYS */;

-- Dump della struttura di tabella molim.sezione_radiomica
CREATE TABLE IF NOT EXISTS `sezione_radiomica` (
  `id_progetto` varchar(3) NOT NULL,
  `esame` varchar(15) NOT NULL,
  `descrizione` varchar(50) NOT NULL,
  `valore_da` decimal(5,2) DEFAULT NULL,
  `valore_a` decimal(5,2) DEFAULT NULL,
  KEY `sezione_radiomica_id_progetto_fkey` (`id_progetto`),
  CONSTRAINT `sezione_radiomica_id_progetto_fkey` FOREIGN KEY (`id_progetto`) REFERENCES `progetti` (`id_progetto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.sezione_radiomica: ~28 rows (circa)
/*!40000 ALTER TABLE `sezione_radiomica` DISABLE KEYS */;
INSERT INTO `sezione_radiomica` (`id_progetto`, `esame`, `descrizione`, `valore_da`, `valore_a`) VALUES
	('NAD', 'amyloid_presenc', 'amyloid_presence', 0.00, 1.00),
	('NAD', 'R_Parietal', 'Right side Parietal Lobe', 0.00, 2.00),
	('NAD', 'L_Parietal', 'Left sise Parietal Lobe', 0.00, 2.00),
	('NAD', 'R_Occipital', 'Right side Occipital Lobe', 0.00, 2.00),
	('NAD', 'L_Occipital', 'Left sise Occipital Lobe', 0.00, 2.00),
	('NAD', 'R_Temporal', 'Right side Temporal Lobe', 0.00, 2.00),
	('NAD', 'L_Temporal', 'Left sise Temporal Lobe', 0.00, 2.00),
	('NAD', 'R_Frontal', 'Right side Frontal Lobe', 0.00, 2.00),
	('NAD', 'L_Frontal', 'Left sise Frontal Lobe', 0.00, 2.00),
	('NAD', 'R_LimbicCortex', 'Right side Limbic Cortex', 0.00, 2.00),
	('NAD', 'L_LimbicCortex', 'Left side Limbic Cortex', 0.00, 2.00),
	('NAD', 'R_Hippocampus', 'Right side Hippocampus', 0.00, 2.00),
	('NAD', 'L_Hippocampus', 'Left side Hippocampus', 0.00, 2.00),
	('NAD', 'R_Amygdala', 'Right side Amygdala', 0.00, 2.00),
	('NAD', 'L_Amygdala', 'Left side Amygdala', 0.00, 2.00),
	('NAD', 'MR Sessions', 'Magnetic Resonance Session', 0.00, 5.00),
	('NAD', 'PET Sessions', 'Positron Emission Tomography Session', 0.00, 5.00),
	('NAD', 'CT Sessions', 'Computed Tomography Session', 0.00, 5.00),
	('NPD', 'amyloid_presenc', 'amyloid_presence', 0.00, 1.00),
	('NPD', 'R_Caudate', 'Right side Caudate', 0.00, 2.00),
	('NPD', 'L_Caudate', 'Left side Caudate', 0.00, 2.00),
	('NPD', 'R_Putamen', 'Right side Putamen', 0.00, 2.00),
	('NPD', 'L_Putamen', 'Left side Putamen', 0.00, 2.00),
	('NPD', 'R_Thalamus', 'Right side Thalamus', 0.00, 2.00),
	('NPD', 'L_Thalamus', 'Left side Thalamus', 0.00, 2.00),
	('NPD', 'MR Sessions', 'Magnetic Resonance Session', 0.00, 5.00),
	('NPD', 'PET Sessions', 'Positron Emission Tomography Session', 0.00, 5.00),
	('NPD', 'CT Sessions', 'Computed Tomography Session', 0.00, 5.00);
/*!40000 ALTER TABLE `sezione_radiomica` ENABLE KEYS */;

-- Dump della struttura di tabella molim.test_neurologici
CREATE TABLE IF NOT EXISTS `test_neurologici` (
  `id_test` varchar(10) NOT NULL,
  `data_inizio_validita` date NOT NULL,
  `data_fine_validita` date NOT NULL,
  `descrizione_test` varchar(100) NOT NULL,
  `cluster` varchar(10) NOT NULL,
  PRIMARY KEY (`id_test`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.test_neurologici: ~25 rows (circa)
/*!40000 ALTER TABLE `test_neurologici` DISABLE KEYS */;
INSERT INTO `test_neurologici` (`id_test`, `data_inizio_validita`, `data_fine_validita`, `descrizione_test`, `cluster`) VALUES
	('BECK_II', '2020-01-01', '2021-12-31', 'Beck Depression', 'cognitivo'),
	('COWAT', '2020-01-01', '2021-12-31', 'Controlled Oral Word Association Test', 'cognitivo'),
	('DIGIT_BW', '2020-01-01', '2021-12-31', 'Backward digit', 'cognitivo'),
	('DIGIT_FW', '2020-01-01', '2021-12-31', 'Forward digit', 'cognitivo'),
	('FAB', '2020-01-01', '2021-12-31', 'FRONTAL ASSESSEMENT BATTERY (FAB)', 'cognitivo'),
	('FCSRT_DFR', '2020-01-01', '2021-12-31', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione differita libera', 'cognitivo'),
	('FCSRT_DTR', '2020-01-01', '2021-12-31', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione differita totale', 'cognitivo'),
	('FCSRT_IFR', '2020-01-01', '2021-12-31', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione libera immediata', 'cognitivo'),
	('FCSRT_ISC', '2020-01-01', '2021-12-31', 'FREE AND CUED SELECTIVE REMINDING TEST - Indice di sensibilita\' al suggerimento semantico', 'cognitivo'),
	('FCSRT_ITR', '2020-01-01', '2021-12-31', 'FREE AND CUED SELECTIVE REMINDING TEST - Rievocazione immediata totale', 'cognitivo'),
	('HAMA', '2020-01-01', '2021-12-31', 'HAMA total score', 'cognitivo'),
	('HeY', '2020-01-01', '2021-12-31', 'Stadiazione clinica Hoehn e Yahr (HeY)', 'motorio'),
	('JLO_V', '2020-01-01', '2021-12-31', 'Judgment of line orientation', 'cognitivo'),
	('MMSE', '2020-01-01', '2021-12-31', 'Mini-Mental State Examination', 'motorio'),
	('RAVLT_RD', '2020-01-01', '2021-12-31', 'Rey Auditory Verbal Learning Test - Rievocazione Differita', 'cognitivo'),
	('RAVLT_RI', '2020-01-01', '2021-12-31', 'Rey Auditory Verbal Learning Test  - Rievocazione Immediata', 'cognitivo'),
	('STROOP_C', '2020-01-01', '2021-12-31', 'Stroop  Test Color', 'cognitivo'),
	('STROOP_CW', '2020-01-01', '2021-12-31', 'Stroop  Test Color and Word', 'cognitivo'),
	('STROOP_W', '2020-01-01', '2021-12-31', 'Stroop  Test Word', 'cognitivo'),
	('TOKEN', '2020-01-01', '2021-12-31', 'Token test', 'cognitivo'),
	('UPDRS_I', '2020-01-01', '2021-12-31', 'Stato mentale, comportamentale e timico', 'motorio'),
	('UPDRS_II', '2020-01-01', '2021-12-31', 'Attivita\' della vita quotidiana (M-EDL)', 'motorio'),
	('UPDRS_III', '2020-01-01', '2021-12-31', 'Esame Motorio', 'motorio'),
	('UPDRS_IV', '2020-01-01', '2021-12-31', 'Complicanze Motorie', 'motorio'),
	('WEIGL', '2020-01-01', '2021-12-31', 'Test di Weigl', 'cognitivo');
/*!40000 ALTER TABLE `test_neurologici` ENABLE KEYS */;

-- Dump della struttura di tabella molim.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dump dei dati della tabella molim.__efmigrationshistory: ~0 rows (circa)
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20210507163813_INIT_01', '3.1.10');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
