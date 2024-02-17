const API_URL = 'https://ort-tallermoviles.herokuapp.com/api'
Inicializar()

function Inicializar() {
  OcultarSecciones()
  AgregarEventos()
}

function OcultarSecciones() {
  let pantallas = document.querySelectorAll('.ion-page')
  for (let i = 1; i < pantallas.length; i++) {
    pantallas[i].style.display = 'none'
  }
}

function AgregarEventos() {
  document
    .getElementById('ruteo')
    .addEventListener('ionRouteWillChange', Navegar)
  document.getElementById('btnLogin').addEventListener('click', Login)
  document.getElementById('btnRegistro').addEventListener('click', Registro)
}

function Navegar(event) {
  OcultarSecciones()
  switch (event.detail.to) {
    case '/':
      document.getElementById('inicio').style.display = 'block'
      break
    case '/Registro':
      document.getElementById('registro').style.display = 'block'
      break
    case '/Login':
      document.getElementById('login').style.display = 'block'
      break
  }
}

function Registro() {
  let nombre = document.getElementById('nombre').value
  let apellido = document.getElementById('apellido').value
  let email = document.getElementById('email').value
  let direccion = document.getElementById('direccion').value
  let password = document.getElementById('password').value
  document.getElementById('mensajesRegistro').innerHTML = ''

  try {
    if (nombre.trim().length === 0) {
      throw new Error('El nombre es requerido')
    }
    if (apellido.trim().length === 0) {
      throw new Error('El apellido es requerido')
    }
    if (email.trim().length === 0) {
      throw new Error('El email es requerido')
    }
    if (direccion.trim().length === 0) {
      throw new Error('La direccion es requerida')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    fetch(`${API_URL}/usuarios`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        nombre,
        apellido,
        email,
        direccion,
        password,
      }),
    })
      .then(response => response.json())
      .then(data => {
        console.log(data)
        if (!data.error) {
          document.getElementById('nombre').value = ''
          document.getElementById('apellido').value = ''
          document.getElementById('email').value = ''
          document.getElementById('direccion').value = ''
          document.getElementById('password').value = ''
          document.getElementById('mensajesRegistro').innerHTML =
            'Registro exitoso, ya puedes iniciar sesion'
        } else {
          document.getElementById('mensajesRegistro').innerHTML = data.error
        }
      })
      .catch(error => console.log(error))
  } catch (error) {
    document.getElementById('mensajesRegistro').innerHTML = error
  }
}

function Login() {
  let email = document.getElementById('emailLogin').value
  let password = document.getElementById('passwordLogin').value
  document.getElementById('mensajesLogin').innerHTML = ''

  try {
    if (email.trim().length === 0) {
      throw new Error('El email es requerido')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    fetch(`${API_URL}/usuarios/session`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        email,
        password,
      }),
    })
      .then(response =>
        response.ok
          ? response.json()
          : Promise.reject({
              status: response.status,
              mensaje: 'Usuario o contraseña incorrectos',
            })
      )
      .then(data => {
        document.getElementById(
          'mensajesLogin'
        ).innerHTML = `Login exitoso, token: ${data.data.token}`
      })
      .catch(
        error =>
          (document.getElementById('mensajesLogin').innerHTML = error.mensaje)
      )
  } catch (error) {
    document.getElementById('mensajesLogin').innerHTML = error.message
  }
}
