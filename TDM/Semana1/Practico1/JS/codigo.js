let hayUsuarioLogueado = false
let paises = new Array()
let usuarios = new Array()
inicializar()

function inicializar() {
  Inicio(true)
  CargarPaises()
  CargarPaisesEnSelect()
  CargarUsuarios()
}
function OcultarDivs() {
  document.querySelector('#login').style.display = 'none'
  document.querySelector('#registro').style.display = 'none'
}
function OcultarBotones(showButtons) {
  if (showButtons) {
    document.querySelector('#btnIngreso').style.display = 'inline'
    document.querySelector('#btnRegistro').style.display = 'inline'
    document.querySelector('#btnCerrarSesion').style.display = 'none'
  } else {
    document.querySelector('#btnCerrarSesion').style.display = 'inline'
  }
}
function AgregarEventos() {
  document
    .querySelector('#btnInicio')
    .addEventListener('click', MostrarOcultarDivs)
  document
    .querySelector('#btnIngreso')
    .addEventListener('click', MostrarOcultarDivs)
  document
    .querySelector('#btnRegistro')
    .addEventListener('click', MostrarOcultarDivs)
  document
    .querySelector('#btnCerrarSesion')
    .addEventListener('click', CerrarSesion)
  document.querySelector('#btnLogin').addEventListener('click', IniciarSesion)
  document
    .querySelector('#btnRegistroUsuario')
    .addEventListener('click', Registro)
}
function CargarPaises() {
  paises.push(new Pais('ARG', 'Argentina'))
  paises.push(new Pais('BRA', 'Brasil'))
  paises.push(new Pais('UYU', 'Uruguay'))
  paises.push(new Pais('PRT', 'Portugal'))
}

function Inicio(showButtons) {
  OcultarDivs()
  OcultarBotones(showButtons)
  AgregarEventos()
  document.querySelector('#inicio').style.display = 'block'
  if (!hayUsuarioLogueado) {
    document.querySelector('#divInicioUsuarioDesconocido').style.display =
      'block'
    document.querySelector('#divInicioUsuarioLogueado').style.display = 'none'
  } else {
    document.querySelector('#divInicioUsuarioDesconocido').style.display =
      'none'
    document.querySelector('#divInicioUsuarioLogueado').style.display = 'block'
    document.querySelector('#login').style.display = 'none'
  }
}

function MostrarOcultarDivs() {
  OcultarDivs()
  switch (this.id) {
    case 'btnInicio':
      document.querySelector('#inicio').style.display = 'block'
      break

    case 'btnRegistro':
      document.querySelector('#registro').style.display = 'block'
      break

    case 'btnIngreso':
      document.querySelector('#login').style.display = 'block'
      break

    case 'btnCerrarSesion':
      OcultarBotones(false)
      break
  }
}
function CargarPaisesEnSelect() {
  let data = ''
  if (paises.length > 0) {
    data += `<option value=-1>Seleccione una opcion..</option>`
  }
  paises.forEach(element => {
    data += `<option value=${element.codigo}>${element.nombre}</option>`
  })

  document.querySelector('#paises').innerHTML = data
}
function IniciarSesion() {
  let nombreUsuario = document.querySelector('#nombreUsuario').value
  let password = document.querySelector('#password').value
  document.querySelector('#errorMessage').innerHTML = ''
  try {
    if (nombreUsuario.trim().length == 0 || password.trim().length == 0) {
      throw new Error('Los datos no son correctos')
    }
    if (BuscarUsuario(nombreUsuario, password)) {
      hayUsuarioLogueado = true
      CargarUsuariosEnTabla()
      Inicio(false)
      document.querySelector('#btnCerrarSesion').style.display = 'inline'
      document.querySelector('#btnIngreso').style.display = 'none'
      document.querySelector('#btnRegistro').style.display = 'none'
    } else {
      throw new Error('Datos incorrectos')
    }
  } catch (Error) {
    document.querySelector('#errorMessage').innerHTML = Error.message
  }
}
function CargarUsuarios() {
  usuarios.push(new Usuario('Lili', 'Pino', 'UYU', 'lili', '1234'))
}
function BuscarUsuario(nombreUsuario, password) {
  let existUser = false
  usuarios.forEach(usu => {
    if (
      usu.nombreUsuario.trim() == nombreUsuario.trim() &&
      usu.password.trim() == password.trim()
    ) {
      existUser = true
    }
  })
  return existUser
}

function CargarUsuariosEnTabla() {
  document.querySelector('#tablaInicioBody').innerHTML = ''
  let users = ''
  usuarios.forEach(user => {
    let Country = BuscarPais(user.codPais)
    users += `<tr><td>${user.nombre}</td><td>${user.apellido}</td><td>${Country.nombre}</td><td>${user.nombreUsuario}</td></tr>`
  })

  document.querySelector('#tablaInicioBody').innerHTML = users
}
function BuscarPais(codPais) {
  return paises.find(element => element.codigo == codPais)
}

function CerrarSesion() {
  hayUsuarioLogueado = false
  document.querySelector('#btnCerrarSesion').style.display = 'none'
  Inicio(true)
}
function Registro() {
  let nombre = document.querySelector('#nombre').value
  let apellido = document.querySelector('#apellido').value
  let nombreUsuario = document.querySelector('#usuario').value
  let password = document.querySelector('#passRegistro').value
  let pass2Registro = document.querySelector('#pass2Registro').value
  let pais = document.querySelector('#paises').value
  document.querySelector('#errorMessageRegistro').innerHTML = ''
  try {
    if (nombre.trim().length == 0) {
      throw new Error('El nombre es requerido')
    }
    if (apellido.trim().length == 0) {
      throw new Error('El apellido es requerido')
    }
    if (nombreUsuario.trim().length == 0) {
      throw new Error('El nombre de usuario es requerido')
    }
    if (password.trim().length == 0) {
      throw new Error('La passwrod es requerida')
    }
    if (
      pass2Registro.trim().length == 0 ||
      pass2Registro.trim() !== password.trim()
    ) {
      throw new Error('Las dos contrasenias no coinciden')
    }
    if (pais.trim().length == 0) {
      throw new Error('El pais es requerido')
    }
    if (!BuscarUsuario(nombreUsuario, password)) {
      document.querySelector('#btnRegistro').style.display = 'none'
      AgregarUsuarioEnArray(
        new Usuario(nombre, apellido, pais, nombreUsuario, password)
      )
      document.querySelector('#errorMessageRegistro').innerHTML =
        'Registro exitoso'
      LimpiarCampos()
    } else {
      throw new Error('Datos incorrectos')
    }
  } catch (Error) {
    document.querySelector('#errorMessageRegistro').innerHTML = Error.message
  }
}
function AgregarUsuarioEnArray(usuario) {
  usuarios.push(usuario)
}

function LimpiarCampos() {
  document.querySelector('#nombre').value = ''
  document.querySelector('#apellido').value = ''
  document.querySelector('#usuario').value = ''
  document.querySelector('#passRegistro').value = ''
  document.querySelector('#pass2Registro').value = ''
  document.querySelector('#paises').value = ''
}
