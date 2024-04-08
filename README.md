-----------------------------------Alta baja de Personas y cursos--------------------------------------------
- Realizado de manera local con C#
- Windows Forms .NET Framework
- Serialización con FileStream y BinaryFormatter
- Para lo que es el guardado de informacion utilicé List
- Herencia, polimorfismo
- Ventanas modales
- Este proyecto se tomó como parte de evaluacion en un final de Programacion. Agregandole mas funcionalidades

- Imagenes:
- Index
- ![index](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/index.jpg)

  
- Boton crear un docente/alumno: Crea una persona
- ![index](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/crear_Persona.jpg?raw=true)

- Boton crear curso: Luego de crear todos las personas, creamos el curso con los docentes disponibles 
- ![boton_crear_curso](https://github.com/IvanSandiyu/Alta.Baja.Mesa/assets/112773633/9a633092-2a2e-4910-8b3a-8f84a21f81a4)

- Boton crear un curso : Como se puede observar, solo se muestran los docentes disponibles, es decir si un docente ya tiene un curso, este no puede tener otro curso
- ![boton_crear_curso2](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/creacion_curso2.jpg?raw=true)

- Boton asignar alumno a un curso : Seleccionamos el alumno al curso que deseemos
- ![asignacion_curso](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/asignar_al_curso.jpg?raw=true)

- Boton mostrar alumnos: Muestra los cursos y los alumnos inscriptos en ella
- ![boton_mostrar](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/mostramos_al_inscriptos.jpg?raw=true)

- Boton limpiar: Muestra todos los cursos disponibles y todas las personas creadas
- ![boton_limpiar](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/boton-limpiar.jpg?raw=true)

- Boton eliminar persona: Elimina la persona, si es alumno se borrará de los cursos en los cuales estaba inscriptos, si es docente se eliminará solo el docente pero el curso seguira existiendo
- ![boton_eliminar_persona](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/boton-limpiar.jpg?raw=true)

- Boton mostrar alumnos luego de borrar una persona: Vemos que desaparecio la persona que estaba en el curso de Atajar
- ![mostrar_al2](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/mostrar_al_inscripts.jpg?raw=true)

- Boton eliminar curso: Se eliminara el curso, el docente asignado al curso seguria existiendo, de modo que estara disponible para un curso nuevamente
- ![curso_eliminado0](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/eliminar_curso.jpg?raw=true)

- Boton limpiar luego de eliminar curso : Confirmamos que desaparecio el curso de la lista
- ![curso_eliminado](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/curso_eliminado.jpg?raw=true)

- Boton mostrar alumnos : El curso se borró de ambas listas
- ![curso_eliminado2](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/docentes_nuevamente_disponibles.jpg?raw=true)

- Aqui verificamos que el docente vuelve a estar disponible
- ![confirmacion_Docente](https://github.com/IvanSandiyu/Alta.Baja.Mesa/blob/main/imagenes/docentes_nuevamente_disponibles.jpg?raw=true)
