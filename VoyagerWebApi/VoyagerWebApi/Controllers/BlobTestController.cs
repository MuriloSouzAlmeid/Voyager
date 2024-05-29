using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Domains;
using VoyagerWebApi.Utils.BlobStorage;
using VoyagerWebApi.ViewModels;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobTestController : ControllerBase
    {
        //[HttpPut("AlterarFotoPerfil")]

        //[FromForm] UsuarioViewModel user

        //UsuarioViewModel é um arquivo por isso fromform 
        //Funcionalidade para atualizar a foto de perfil do usuário
        //public async Task<IActionResult> UploadProfileImage(Guid id)
        //{
        //    try
        //    {
        //        //Buscar usuario
        //        //Usuario usuarioBuscado = usuarioRepository.BuscarPorId(id);

        //        //if (usuarioBuscado == null)
        //        //{
        //        //    return NotFound("Usuário não encontrado");
        //        //}

        //        //Lógica para o upload da imagem

        //        //Define o nome a partir do seu container no blob      
        //        var containerName = "voyagerblobstorage";

        //        //Define a string de conexão
        //        var connectionString = "DefaultEndpointsProtocol=https;AccountName=voyagerblobstorage;AccountKey=KUCXzCqDYUNdIBbY9AM/qA1EA0Rw95VMMrT/+ceKyOwa/HbDiTmQlh6QN6beAAw0g/GQx/55x37k+AStjnaDRA==;EndpointSuffix=core.windows.net";

        //        //string fotoUrl = await AzureBlobStorageHelper.UploadImageBlobAsync(user.Arquivo!, connectionString, containerName);

        //        //Fim da lógica para upload de imagem

        //        //usuarioRepository.AtualizarFoto(id, fotoUrl);

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BlobTestViewModel blobModel)
        {
            try
            {
                //Aqui iremos configurar e utilizar o método de upload image

                //Define o nome a partir do seu container no blob
                var containerName = "voyagercontainerblob";

                //Definindo a string de conexão
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=voyagerblobstorage;AccountKey=KUCXzCqDYUNdIBbY9AM/qA1EA0Rw95VMMrT/+ceKyOwa/HbDiTmQlh6QN6beAAw0g/GQx/55x37k+AStjnaDRA==;EndpointSuffix=core.windows.net";

                //A chamada da função de upload de imagem
                 await AzureBlobStorageHelper.UploadImageBlobAsync(blobModel.File!, connectionString, containerName);

   
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
