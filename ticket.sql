-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-08-2017 a las 07:03:28
-- Versión del servidor: 10.1.25-MariaDB
-- Versión de PHP: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `ticket`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `puesto` varchar(20) NOT NULL,
  `telefono` varchar(16) NOT NULL,
  `domicilio` varchar(150) DEFAULT NULL,
  `tipo` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`id`, `nombre`, `puesto`, `telefono`, `domicilio`, `tipo`, `created_at`, `updated_at`, `updated_by`) VALUES
(1, 'Gibran Alfredo Piedra Rosas', 'Ingeniero', '6672306153', 'Conocido', 2, '2017-08-17 04:34:12', '2017-08-17 04:47:43', 0),
(2, 'Gadi Sibrain Sauceda Urias', 'Alarmas', '6672383622', 'Conocido', 2, '2017-08-17 04:35:33', '2017-08-17 04:35:33', 1),
(3, 'Juan Bautista ', 'Soporte', '', 'Conocido', 2, '2017-08-17 04:36:15', '2017-08-17 04:36:15', 0),
(4, 'Julio Cesar', 'Tecnico', '667', 'Conocido', 2, '2017-08-17 04:36:56', '2017-08-17 04:36:56', 0),
(5, 'Itzel Garate', 'Monitorista', '667', 'Conocido', 1, '2017-08-17 04:37:29', '2017-08-17 04:37:29', 0),
(6, 'Luis Ebel', 'Monitorista', '667', 'Conocido', 1, '2017-08-17 04:37:59', '2017-08-17 04:37:59', 1),
(7, 'Ruben Darío Piedra Rosas', 'Director', '667', 'Conocido', 3, '2017-08-17 04:38:36', '2017-08-17 04:38:36', 1),
(8, 'Rosario Beltran', 'Recursos humanos', '667', 'Conocido', 3, '2017-08-17 04:39:23', '2017-08-17 04:39:23', 0),
(9, 'Mayra Orona', 'Secretaria', '667', 'Conocido', 3, '2017-08-17 04:40:22', '2017-08-17 04:40:22', 0),
(10, 'Isis García', 'Proyecto', '667', 'Conocido', 3, '2017-08-17 04:41:05', '2017-08-17 04:41:05', 1),
(11, 'Aldo Armenta', 'Monitorista', '667', 'Conocido', 1, '2017-08-17 04:44:59', '2017-08-17 04:44:59', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado`
--

CREATE TABLE `estado` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `estado`
--

INSERT INTO `estado` (`id`, `nombre`, `descripcion`, `created_at`, `updated_at`, `updated_by`) VALUES
(1, 'Sin revisar', 'Significa que se dio de alta el ticket pero no ha sido asignado o no es tan relevante', '2017-08-17 04:50:07', '2017-08-17 04:50:07', 1),
(2, 'Asignado', 'Significa que el responsable de resolver el ticket ha sido avisado', '2017-08-17 04:52:05', '2017-08-17 04:52:05', 1),
(3, 'En proceso', 'Significa que el responsable ha atendido el ticket y esta en proceso de resolverlo', '2017-08-17 04:52:05', '2017-08-17 04:52:05', 0),
(4, 'Finalizado', 'Significa que el ticket ha sdo resuelto', '2017-08-17 04:52:55', '2017-08-17 04:52:55', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `historialticket`
--

CREATE TABLE `historialticket` (
  `id` int(11) NOT NULL,
  `ticket` int(11) NOT NULL,
  `estadoAnterior` int(11) NOT NULL,
  `estadoActual` int(11) NOT NULL,
  `falla` text NOT NULL,
  `causa` text,
  `observaciones` text,
  `tipoTicket` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ticket`
--

CREATE TABLE `ticket` (
  `id` int(11) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `horaLlegadaMin` time DEFAULT NULL,
  `horaLlegadaMax` time DEFAULT NULL,
  `alta` int(11) NOT NULL,
  `asignado` int(11) NOT NULL,
  `cliente` text NOT NULL,
  `falla` text NOT NULL,
  `causa` text,
  `observaciones` text,
  `estado` int(11) NOT NULL,
  `tipoTicket` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipoticket`
--

CREATE TABLE `tipoticket` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `updated_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `tipoticket`
--

INSERT INTO `tipoticket` (`id`, `nombre`, `descripcion`, `created_at`, `updated_at`, `updated_by`) VALUES
(1, 'Ticket \"A\"', 'Son los tickets con mayor prioridad, es urgente resolverlo', '2017-08-17 04:54:58', '2017-08-17 04:54:58', 1),
(2, 'Ticket \"B\"', 'Son los tickets con prioridad alta, es importante resolverlo', '2017-08-17 04:54:58', '2017-08-17 04:54:58', 0),
(3, 'Ticket \"C\"', 'Son los tickets con prioridad baja, es necesario resolverlo', '2017-08-17 05:01:45', '2017-08-17 05:01:45', 0),
(4, 'Ticket Proyecto', 'Son los tickets con proposito de asignar tareas de proyectos específicos', '2017-08-17 05:01:45', '2017-08-17 05:01:45', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `estado`
--
ALTER TABLE `estado`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `historialticket`
--
ALTER TABLE `historialticket`
  ADD PRIMARY KEY (`id`),
  ADD KEY `estatusAnterior` (`estadoAnterior`),
  ADD KEY `estatusActual` (`estadoActual`),
  ADD KEY `ticket` (`ticket`);

--
-- Indices de la tabla `ticket`
--
ALTER TABLE `ticket`
  ADD PRIMARY KEY (`id`),
  ADD KEY `estado` (`estado`),
  ADD KEY `tipoTicket` (`tipoTicket`),
  ADD KEY `alta` (`alta`),
  ADD KEY `asignado` (`asignado`),
  ADD KEY `updated_by` (`updated_by`);

--
-- Indices de la tabla `tipoticket`
--
ALTER TABLE `tipoticket`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT de la tabla `estado`
--
ALTER TABLE `estado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `historialticket`
--
ALTER TABLE `historialticket`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `ticket`
--
ALTER TABLE `ticket`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `tipoticket`
--
ALTER TABLE `tipoticket`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `historialticket`
--
ALTER TABLE `historialticket`
  ADD CONSTRAINT `historialticket_ibfk_1` FOREIGN KEY (`estadoAnterior`) REFERENCES `estado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `historialticket_ibfk_2` FOREIGN KEY (`estadoActual`) REFERENCES `estado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `ticket`
--
ALTER TABLE `ticket`
  ADD CONSTRAINT `ticket_ibfk_1` FOREIGN KEY (`tipoTicket`) REFERENCES `tipoticket` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ticket_ibfk_2` FOREIGN KEY (`estado`) REFERENCES `estado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ticket_ibfk_3` FOREIGN KEY (`alta`) REFERENCES `empleado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ticket_ibfk_4` FOREIGN KEY (`asignado`) REFERENCES `empleado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ticket_ibfk_5` FOREIGN KEY (`id`) REFERENCES `historialticket` (`ticket`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
