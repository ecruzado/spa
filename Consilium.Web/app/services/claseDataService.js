app.factory('claseDataService', function ($http, $log, toaster) {

    var claseDataFactory = {};

    var _niveles = function () {
        return $http.get('/api/nivel/', { params: {} }).then(function (results) {
            return results;
        });
    };

    var _grados = function (nivelId) {
        return $http.get('/api/grado/', { params: { nivelId: nivelId } }).then(function (results) {
            return results;
        });
    };

    var _claseCapacidades = function (claseId) {
        return $http.get('/api/clasecapacidad/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseCapacidad = function (claseCapacidad) {
        return $http.post('/api/clasecapacidad/', claseCapacidad).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Capacidad agregada satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _deleteClaseCapacidad = function (claseCapacidadId) {
        return $http.delete('/api/clasecapacidad/' + claseCapacidadId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Capacidad eliminada satisfactoriamente!");
            },
            function (results) {
                alert('error');
                return results;
            }
        );
    };
    var _clases = function (busqueda) {
        return $http.post('/api/clasebusqueda/', busqueda).then(function (results) {
            return results;
        });
    };
    var _clase = function (claseId) {
        return $http.get('/api/clase/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };

    var _saveClase = function (clase) {
        return $http.post('/api/clase/', clase).then(function (resultado) {
            toaster.pop('success', "Guardado Satisfactoriamente", "Clase guardada satisfactoriamente!");
            return resultado;
        }, function (error) {
            alert('Error');
        });
    };
    var _deleteClase = function (claseId) {
        return $http.delete('/api/clase/' + claseId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Clase eliminada satisfactoriamente!");
            },
            function (results) {
                alert('Error');
                return results;
            }
        );
    };
    var _claseContenidos = function (claseId) {
        return $http.get('/api/clasecontenido/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseContenido = function (claseContenido) {
        return $http.post('/api/clasecontenido/', claseContenido).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Contenido agregado satisfactoriamente!");
            },
            function (results) {
                alert('Error');
                return results;
            }
        );
    };
    var _deleteClaseContenido = function (claseContenidoId) {
        return $http.delete('/api/clasecontenido/' + claseContenidoId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Contenido eliminado satisfactoriamente!");
            },
            function (results) {
                alert('Error');
                return results;
            }
        );
    };

    var _claseValores = function (claseId) {
        return $http.get('/api/clasevalor/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseValor = function (claseValor) {
        return $http.post('/api/clasevalor/', claseValor).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Valor agregado satisfactoriamente!");
            },
            function (results) {
                alert('Error');
                return results;
            }
        );
    };
    var _deleteClaseValor = function (claseValorId) {
        return $http.delete('/api/clasevalor/' + claseValorId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Valor eliminado satisfactoriamente!");
            },
            function (results) {
                alert('Error');
                return results;
            }
        );
    };

    var _claseMetodos = function (claseId) {
        return $http.get('/api/clasemetodo/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseMetodo = function (claseMetodo) {
        return $http.post('/api/clasemetodo/', claseMetodo).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Metodo agregado satisfactoriamente!");
            },
            function (results) {
                alert('Error');
                return results;
            }
        );
    };
    var _deleteClaseMetodo = function (claseMetodoId) {
        return $http.delete('/api/clasemetodo/' + claseMetodoId).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Metodo eliminado satisfactoriamente!");
            },
            function (results) {
                alert('Error');
                return results;
            }
        );
    };

    var _claseActividades = function (claseId) {
        return $http.get('/api/claseactividad/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _claseActividadUpdate = function (claseActividad) {
        return $http.post('/api/claseactividad/', claseActividad).then(function (results) {
            return results;
        });
    };
    var _claseMatriz = function (claseId) {
        return $http.get('/api/clasematriz/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseMatriz = function (claseMatriz) {
        return $http.post('/api/clasematriz/', claseMatriz).then(
            function (results) {
                toaster.pop('success', "Guardado Satisfactoriamente", "Matriz guardada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };

    var _areas = function () {
        return $http.get('/api/area/').then(function (results) {
            return results;
        });
    };
    var _usuarios = function (colegioId) {
        return $http.get('/api/usuario/', { params: { colegioId: colegioId } }).then(function (results) {
            return results;
        });
    };

    var _claseColumnas = function (claseId,columnaId) {
        return $http.get('/api/clasecolumna/', { params: { claseId: claseId , columnaId:columnaId} }).then(function (results) {
            return results;
        });
    };
    var _saveClaseColumna = function (claseColumna) {
        return $http.post('/api/clasecolumna/', claseColumna).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Columna agregada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };
    var _deleteClaseColumna = function (id) {
        return $http.delete('/api/clasecolumna/' + id).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Columna eliminada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };

    var _claseConocimientos = function (claseId) {
        return $http.get('/api/claseconocimiento/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseConocimiento = function (claseConocimiento) {
        return $http.post('/api/claseconocimiento/', claseConocimiento).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Conocimiento agregada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };
    var _deleteClaseConocimiento = function (id) {
        return $http.delete('/api/claseconocimiento/' + id).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Conocimiento eliminada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };


    var _clasePruebas = function (claseId) {
        return $http.get('/api/claseprueba/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClasePrueba = function (clasePrueba) {
        return $http.post('/api/claseprueba/', clasePrueba).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Prueba agregada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };
    var _deleteClasePrueba = function (id) {
        return $http.delete('/api/claseprueba/' + id).then(
            function (results) {
                toaster.pop('success', "Eliminada Satisfactoriamente", "Prueba eliminada satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };

    var _claseArchivos = function (claseId) {
        return $http.get('/api/clasearchivo/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseArchivo = function (claseArchivo) {
        return $http.post('/api/clasearchivo/', claseArchivo).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Archivo agregado satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };
    var _deleteClaseArchivo = function (ids) {
        return $http.delete('/api/clasearchivo/', { params: { ids: ids } }).then(
            function (results) {
                toaster.pop('success', "Eliminado Satisfactoriamente", "Archivo eliminado(s) satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };

    var _claseComentarios = function (claseId) {
        return $http.get('/api/clasecomentario/', { params: { claseId: claseId } }).then(function (results) {
            return results;
        });
    };
    var _saveClaseComentario = function (claseArchivo) {
        return $http.post('/api/clasecomentario/', claseArchivo).then(
            function (results) {
                toaster.pop('success', "Agregado Satisfactoriamente", "Comentario agregado satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };
    var _deleteClaseComentario = function (ids) {
        return $http.delete('/api/clasecomentario/', { params: { ids: ids } }).then(
            function (results) {
                toaster.pop('success', "Eliminado Satisfactoriamente", "Comentario eliminado(s) satisfactoriamente!");
            },
            function (results) {
                return results;
            }
        );
    };

    claseDataFactory.niveles = _niveles;
    claseDataFactory.grados = _grados;

    claseDataFactory.clases = _clases;
    claseDataFactory.clase = _clase;
    claseDataFactory.saveClase = _saveClase;
    claseDataFactory.deleteClase = _deleteClase;
    
    claseDataFactory.claseCapacidades = _claseCapacidades;
    claseDataFactory.saveClaseCapacidad = _saveClaseCapacidad;
    claseDataFactory.deleteClaseCapacidad = _deleteClaseCapacidad;

    claseDataFactory.claseContenidos = _claseContenidos;
    claseDataFactory.saveClaseContenido = _saveClaseContenido;
    claseDataFactory.deleteClaseContenido = _deleteClaseContenido;

    claseDataFactory.claseValores = _claseValores;
    claseDataFactory.saveClaseValor = _saveClaseValor;
    claseDataFactory.deleteClaseValor = _deleteClaseValor;

    claseDataFactory.claseMetodos = _claseMetodos;
    claseDataFactory.saveClaseMetodo = _saveClaseMetodo;
    claseDataFactory.deleteClaseMetodo = _deleteClaseMetodo;

    claseDataFactory.claseActividades = _claseActividades;
    claseDataFactory.claseActividadUpdate = _claseActividadUpdate;

    claseDataFactory.claseMatriz = _claseMatriz;
    claseDataFactory.saveClaseMatriz = _saveClaseMatriz;

    claseDataFactory.areas = _areas;
    claseDataFactory.usuarios = _usuarios;

    claseDataFactory.claseColumnas = _claseColumnas;
    claseDataFactory.saveClaseColumna = _saveClaseColumna;
    claseDataFactory.deleteClaseColumna = _deleteClaseColumna;

    claseDataFactory.claseConocimientos = _claseConocimientos;
    claseDataFactory.saveClaseConocimiento = _saveClaseConocimiento;
    claseDataFactory.deleteClaseConocimiento = _deleteClaseConocimiento;

    claseDataFactory.clasePruebas = _clasePruebas;
    claseDataFactory.saveClasePrueba = _saveClasePrueba;
    claseDataFactory.deleteClasePrueba = _deleteClasePrueba;

    claseDataFactory.claseArchivos = _claseArchivos;
    claseDataFactory.saveClaseArchivo = _saveClaseArchivo;
    claseDataFactory.deleteClaseArchivo = _deleteClaseArchivo;
    
    claseDataFactory.claseComentarios = _claseComentarios;
    claseDataFactory.saveClaseComentario = _saveClaseComentario;
    claseDataFactory.deleteClaseComentario = _deleteClaseComentario;

    return claseDataFactory;
});