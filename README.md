# API Correios
## Table of Contents

* [Overview](#overview)
* [Documentation](#documentation)
* [License](#license)
* [Support](#support)
* [About](#about)

## Overview

## Documentation

### Get list of address

#### Request

`GET /Cep/`

    curl -i -H 'Accept: application/json' https://apicorreios.onrender.com/Cep?cep=30535065&isRawData=false

#### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2
    
    [{"rua":"foo","bairro":"foo","cidade":"foo","cep":"foo","uf":"foo","cepType":"Rua/Bairro/Cidade"}]
    
## License

* **Licensing for open source projects:**  
  ApiCorreios is available under the terms of the [GNU Affero General Public License version 3](http://www.gnu.org/licenses/agpl-3.0.html) as published by the Free Software Foundation.

## Support

Pick one of the options that best suits your needs:
* [gabrieldepaula007@gmail.com](mailto:gabrieldepaula007@gmail.com)

## About

ApiCorreios has been written by [Gabriel de Paula Silva](https://www.linkedin.com/in/gabriel-depaula16/).  
