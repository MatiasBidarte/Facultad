document.querySelector('#guardar').addEventListener('click', MostrarMensaje)
document.querySelector('#mensaje').innerHTML = ''

function MostrarMensaje() {
  try {
    let nombre = document.getElementById('nombre').value.trim()
    let apellido = document.querySelector('#apellido').value.trim()
    let grupo = document.getElementById('grupos').value.trim()
    console.log(grupo)
    document.querySelector('#mensaje').innerHTML = ''
    if (nombre.length <= 0) {
      throw new Error('El nombre no puede ser nulo')
    }
    if (apellido.length <= 0) {
      throw new Error('El apellido no puede ser nulo')
    }
    if (grupo == 0) {
      throw new Error('Seleccione un grupo')
    }

    document.querySelector(
      '#mensaje'
    ).innerHTML = `Hola ${nombre} ${apellido} del grupo ${grupo}`
  } catch (error) {
    document.querySelector('#mensaje').innerHTML = error.message
  }
}
