README — Generación, Exportación, Envío por Email y SFTP


Este sistema permite generar y enviar automáticamente un fichero semanal con las ventas de cada empresa.
✔️ Qué hace el botón “Generar”
Al pulsarlo:
- Se toma la empresa y la semana seleccionadas.
- Se crea un fichero con las ventas correspondientes a esa empresa durante esa semana creado a partir de un fichero maestro que contiene un histórico de ventas.
- El fichero se guarda con un nombre estándar: "empresa_XX_YYYYMMDD_YYYYMMDD.txt"
- El fichero se envía automáticamente por correo electrónico.
- El mismo fichero se sube también al servidor SFTP configurado.

✔️ Dónde se guarda el fichero
El archivo generado se guarda en la carpeta: EXPORT dentro del directorio del programa.

✔️ Qué recibe el cliente
- Un correo con el fichero adjunto.
- El fichero también queda disponible en el servidor SFTP.

✔️ Qué debe hacer el usuario
Solo seleccionar la empresa, seleccionar la semana y pulsar Generar.


