-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 21, 2022 at 08:54 AM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `itbook_test`
--

-- --------------------------------------------------------

--
-- Table structure for table `favor`
--

CREATE TABLE `favor` (
  `favor_id` int(11) NOT NULL,
  `favor_book_id` bigint(20) NOT NULL,
  `favor_user_id` int(11) NOT NULL,
  `favor_create_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `favor_update_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `favor`
--

INSERT INTO `favor` (`favor_id`, `favor_book_id`, `favor_user_id`, `favor_create_at`, `favor_update_at`) VALUES
(2, 9780596100896, 2, '2022-10-19 16:07:44', '2022-10-19 16:07:44'),
(3, 9780596100896, 2, '2022-10-20 15:54:04', '2022-10-20 15:54:04'),
(4, 9780596100896, 2, '2022-10-20 15:55:31', '2022-10-20 15:55:31'),
(5, 9781849510608, 2, '2022-10-20 16:15:30', '2022-10-20 16:15:30'),
(6, 9780596100896, 2, '2022-10-20 16:16:24', '2022-10-20 16:16:24'),
(7, 9780596100896, 2, '2022-10-20 16:21:23', '2022-10-20 16:21:23'),
(8, 9780596100896, 2, '2022-10-21 04:23:49', '2022-10-21 04:23:49');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `user_username` text NOT NULL,
  `user_password` text NOT NULL,
  `user_fullname` text NOT NULL,
  `user_create_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `user_update_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `user_username`, `user_password`, `user_fullname`, `user_create_at`, `user_update_at`) VALUES
(2, 'jirayu.co', 'AKwFYplWH/DcI8yc1drcgqkk+HWwctmWwSO6mCCgbDvFIuokyqv5xTZhG8xA9OVanQ==', 'jirayu.co', '2022-10-19 07:02:57', '2022-10-19 07:02:57'),
(3, 'jirawet.ch', 'AF9gaf44Gm0BswvdqiD7CQO8EiAZrtcdOZwVnyLwuTXb6Z66C3YxCAY4WBGfUXY3hQ==', 'jirawet.ch', '2022-10-19 15:58:40', '2022-10-19 15:58:40'),
(4, 'jirayu.test.4307', 'AJnXmmdDML4WjtfVnsj0tYk6aOcLff/iw7ZH5C2ftiaLBifjRxHbAI++4Rh+Ne047Q==', 'jirayu.test.4307', '2022-10-20 08:43:08', '2022-10-20 08:43:08'),
(5, 'jirayu.test.4525', 'AFiySkO+DjwDtMZ4a5u/MSmyKDIXei/g9BYDWLHX3nWQSvsHDcBZzvc6eP6us4uJyA==', 'jirayu.test.4525', '2022-10-20 08:45:25', '2022-10-20 08:45:25'),
(6, 'jirayu.test.4616', 'ABDD1siNCuvqM29r/NdwvirNFbUi08777MROr3VXdadnkiTeCVIES8WaSSv+vUEsjA==', 'jirayu.test.4616', '2022-10-20 08:46:16', '2022-10-20 08:46:16'),
(7, 'jirayu.test.5946', 'AK1e/tghCnoxF7vg7+NAKgcqjxcHoAJcwbbNgK2FMw9GCrV9Uev4b/gLsze3qv05/A==', 'jirayu.test.5946', '2022-10-20 08:59:46', '2022-10-20 08:59:46'),
(8, 'jirayu.test.0234', 'AP2eMoDz7GIK24qcYGx7OO3snlmgh7yU7KUAwW4etO+fmIOqyZOIvGcPWV89dP4kuQ==', 'jirayu.test.0234', '2022-10-20 09:02:34', '2022-10-20 09:02:34'),
(9, 'jirayu.test.1921', 'AAoTFdoq7knLXUYz0fXrQ6nV1iGkIHwP0ZpGQcXJF2Z4AIOMHa7j3c7IHiFlLJ5P+g==', 'jirayu.test.1921', '2022-10-20 09:19:21', '2022-10-20 09:19:21'),
(10, 'jirayu.test.1953', 'AGqSAL0iPT9Ra5IFDJeN01v82FWOmRd+bmAMznK8CiKndDHsRa/vpz/hx45R6m0uBA==', 'jirayu.test.1953', '2022-10-20 09:19:53', '2022-10-20 09:19:53'),
(11, 'jirayu.test.2019', 'AHgfsmAJU6nxelm2w6bcc/3SQ41+IbyWNatwT6k61gEJhEj8xE+tX83vIkoni5BDaA==', 'jirayu.test.2019', '2022-10-20 09:20:19', '2022-10-20 09:20:19'),
(12, 'jirayu.test.2200', 'ACUJzibbuR7S7UaA2WUQZagjQiQpZzmTw1NKmZzyRrLdHF+Tl9qMg5cVg3D5iYWfSA==', 'jirayu.test.2200', '2022-10-20 09:22:00', '2022-10-20 09:22:00'),
(13, 'jirayu.test.2233', 'AIFbr7m21/v9pkh93xCSDnu/kKJKh0qEMD941B/NCftJpJ7Vws4ZpPOV4CpE4JnxmQ==', 'jirayu.test.2233', '2022-10-20 09:22:33', '2022-10-20 09:22:33'),
(14, 'jirayu.test.2245', 'APNs6fE5UZ6BeXbU6muyLQx1dd9oynPEsI8pEtZ6syOFu+sGhzQiiZcXOyOYUmdafw==', 'jirayu.test.2245', '2022-10-20 09:22:45', '2022-10-20 09:22:45'),
(15, 'jirayu.test.2358', 'AOJwhj9HMqtikEXPvHzWvtt6OtAiKrokcjxS7ee5xHsSmlUcxSGi8HWZXlNdo4n/pA==', 'jirayu.test.2358', '2022-10-20 09:23:58', '2022-10-20 09:23:58'),
(16, 'jirayu.test.2409', 'AHHkGHJUu1TrmtHfbHkcEa3BwcBDOD8n79UBeMRrUWfJy3MAZy7uGlVIN/47Z9U/pQ==', 'jirayu.test.2409', '2022-10-20 09:24:09', '2022-10-20 09:24:09'),
(17, 'jirayu.test.4053', 'AGESTebiTdPX+Hv9MjMjdVR1QCLyf7gmFwVfmD5CYjSqCGSRUuR6sEkuQAsxyxZWGA==', 'jirayu.test.4053', '2022-10-20 14:40:53', '2022-10-20 14:40:53'),
(18, 'jirayu.test.4257', 'AAF36914GVMeFe+h5jxOqSTAhAPSgOFhOax7E757beegqvapaTtGauchS9m5f9TsSA==', 'jirayu.test.4257', '2022-10-20 14:42:57', '2022-10-20 14:42:57'),
(19, 'jirayu.test.4441', 'AAKZaIIdra+DJhq9UDT9CCikqIzfcvysWUEwfJm7JtN0ROKVNQLIVCzDJp2gw3SsRg==', 'jirayu.test.4441', '2022-10-20 14:44:41', '2022-10-20 14:44:41'),
(20, 'jirayu.test.4548', 'AOm6o/CWj5QOP9/5Rj+CPekoU53x8ClLTWRvo9Fa/KA5JuT3DYynWt7HvLK2z/in5A==', 'jirayu.test.4548', '2022-10-20 14:45:48', '2022-10-20 14:45:48'),
(21, 'jirayu.test.5640', 'APDRhUsoMiujKga5csNhA8EnXEtiFPA6cYai1W7z6EJQl5U5GW0tvE2pxLLY7fetKw==', 'jirayu.test.5640', '2022-10-20 14:56:40', '2022-10-20 14:56:40'),
(22, 'jirayu.test.5531', 'AHRWyc8yQRL/7r34bvLNfRuE1bIH7mUS951R+Wey9QlvfGrDp6OcYnXnMWIZuNXuZw==', 'jirayu.test.5531', '2022-10-20 15:55:31', '2022-10-20 15:55:31'),
(23, 'jirayu.test.1623', 'AAJIB9qkWXpejbSwmbkynBe697pxubak2svos2xMXYHXy+6vJudtaP7p6/4neCjKBg==', 'jirayu.test.1623', '2022-10-20 16:16:23', '2022-10-20 16:16:23'),
(24, 'jirayu.test.2122', 'ADbu7Y60IFKmDHvXNorgbF+2ErwIhCetatUdM3VfefRYeU0pGYis5ED2trDbFIjsFQ==', 'jirayu.test.2122', '2022-10-20 16:21:22', '2022-10-20 16:21:22'),
(25, 'jirayu.test.2347', 'AP8FWZopBuBJoQqD+ygNd+vH+VBQrnI4GTz9FfDD0A48JB3bI5gJHkyjDgsZwnMvPw==', 'jirayu.test.2347', '2022-10-21 04:23:47', '2022-10-21 04:23:47');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `favor`
--
ALTER TABLE `favor`
  ADD PRIMARY KEY (`favor_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `favor`
--
ALTER TABLE `favor`
  MODIFY `favor_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
