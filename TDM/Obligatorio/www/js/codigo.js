const API_URL = 'https://calcount.develotion.com'
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
  document.getElementById('btnRegistro').addEventListener('click', Registro)
  document.getElementById('btnLogin').addEventListener('click', Login)
  document.getElementById('btnAgregarAlimento').addEventListener('click', AgregarAlimento)
}

function Navegar(event) {
  console.log(event);
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
    case "/CerrarSesion":
      CerrarSesion()
      ruteo.push("/")
      break
    case '/AgregarAlimento':
      document.getElementById('agregarAlimento').style.display = 'block'
      break
  }
}

function CerrarMenu() {
  document.getElementById('menu').close()
}

function Registro() {
  let usuario = document.getElementById('usuario').value
  let password = document.getElementById('password').value
  let idPais = document.getElementById('pais').value
  let calorias = document.getElementById('calorias').value
  document.getElementById('mensajesRegistro').innerHTML = ''

  try {
    if (usuario.trim().length === 0) {
      throw new Error('El usuario es requerido')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    if (idPais === '') {
      throw new Error('El id de pais es requerido')
    }
    if (calorias === '') {
      throw new Error('La cantidad de calorias son requeridas')
    }
    fetch(`${API_URL}/usuarios.php`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        usuario,
        password,
        idPais,
        caloriasDiarias: calorias,
      }),
    })
      .then(response => response.json())
      .then(data => {
        console.log(data)
        if (data.codigo === 200) {
          localStorage.setItem('apiKey', data.apiKey)
          localStorage.setItem('idUsuario', data.id)
          ruteo.push('/')
        } else {
          document.getElementById('mensajesRegistro').innerHTML = data.mensaje
        }
      })
      .catch(error => console.log(error))
  } catch (error) {
    document.getElementById('mensajesRegistro').innerHTML = error.message
  }
}

function Login() {
  let usuario = document.getElementById('usuarioLogin').value
  let password = document.getElementById('passwordLogin').value
  document.getElementById('mensajesLogin').innerHTML = ''

  try {
    if (usuario.trim().length === 0) {
      throw new Error('El usuario es requerido')
    }
    if (password.trim().length === 0) {
      throw new Error('La contraseña es requerida')
    }
    fetch(`${API_URL}/login.php`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        usuario,
        password,
      }),
    })
      .then(response =>
        response.ok
          ? response.json()
          : Promise.reject({
              status: response.status,
              mensaje: 'Usuario y/o contraseña incorrectos',
            })
      )
      .then(data => {
        document.getElementById('mensajeLogin').innerHTML = `Login exitoso`
        localStorage.setItem('apiKey', data.apiKey)
        localStorage.setItem('idUsuario', data.id)
      })
      .catch(
        error =>
          (document.getElementById('mensajeLogin').innerHTML = error.mensaje)
      )
  } catch (error) {
    document.getElementById('mensajeLogin').innerHTML = error.message
  }
}

function AgregarAlimento() {
  if (localStorage.getItem('apiKey') === null) {
    document.getElementById('mensajeAgregarAlimento').innerHTML = 'Debe iniciar sesión para agregar un alimento'
  } else {
    let alimento = document.getElementById('alimento').value
    let cantidad = document.getElementById('cantidadAlimento').value
    let fechaInicial = document.getElementById('fechaAlimento').value
    let idUsuario = localStorage.getItem('idUsuario')
    let apiKey = localStorage.getItem('apiKey')
    try {
      if (alimento.trim().length === 0) {
        throw new Error('El alimento es requerido')
      }
      if (cantidad.trim().length === 0) {
        throw new Error('La cantidad de alimento es requerida')
      }
      if (fechaInicial.trim().length === 0) {
        throw new Error('La fecha es requerida')
      }

      let fecha = fechaInicial.split('T')[0]
      if (fecha > new Date().toISOString().split('T')[0]) {
        throw new Error('La fecha no puede ser mayor a la actual')
      }

      fetch(`${API_URL}/alimentos.php`, {
        headers: {
          'Content-Type': 'application/json',
          'apikey': apiKey,
          'iduser': idUsuario
        }
      })
        .then(response => response.json())
        .then(data => {
          if (data.codigo === 200) {
            let alimentos = data.alimentos
            let i = 0
            while (i < alimentos.length) {
              if (alimentos[i].id == alimento) {
                break
              }
              i++
            }
            if (i === alimentos.length) {
              document.getElementById('mensajesAgregarAlimento').innerHTML = 'El alimento no existe'
            } else {
              fetch(`${API_URL}/registros.php`, {
                method: 'POST',
                headers: {
                  'Content-Type': 'application/json',
                  'apikey': apiKey,
                  'iduser': idUsuario
                },
                body: JSON.stringify({
                  alimento,
                  idUsuario,
                  cantidad,
                  fecha
                }),
              })
                .then(response => response.json())
                .then(data => {
                  document.getElementById('mensajesAgregarAlimento').innerHTML = data.mensaje
                })
                .catch(error => console.log(error))
            }
          }
          else {
            document.getElementById('mensajesAgregarAlimento').innerHTML = data.mensaje
          }
        })
        .catch(error => console.log(error))
    } catch (error) {
      document.getElementById('mensajesAgregarAlimento').innerHTML = error.message
    }
  }
}

function VerificarAlimentoExiste(id) {
  let alimentos = ObtenerAlimentos()
  let resultado = false
  let i = 0
  while (i < alimentos.length) {
    if (alimentos[i].id === id) {
      resultado = true
      break
    }
    i++
  }
  return resultado
}

function ObtenerAlimentos() {
  let alimentos = []
  let idUsuario = localStorage.getItem('idUsuario')
  let apiKey = localStorage.getItem('apiKey')
  fetch(`${API_URL}/alimentos.php`, {
    headers: {
      'Content-Type': 'application/json',
      'apikey': apiKey,
      'iduser': idUsuario
    }
  })
    .then(response => response.json())
    .then(data => {
      if (data.codigo === 200) {
        console.log(data.alimentos)
        alimentos = data.alimentos
      }
    })
    .catch(error => console.log(error))
  return alimentos
}

function CerrarSesion() {
  localStorage.clear();
}