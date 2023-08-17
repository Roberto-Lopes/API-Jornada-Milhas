using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace api_jornada_milhas.Integration
{
    public class OpenAiChatGPT
    {
        public OpenAIService Service { get; private set; }

        public OpenAiChatGPT()
        {
            Service = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = "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"
            });
        }

        public async Task<string> GerarTextoDescritivo(string Destino)
        {
            var completionResult = await Service.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = "Faça um resumo sobre" + Destino + "enfatizando o porque este lugar é incrível. Utilize uma linguagem informal e até 100 caracteres no máximo em cada parágrafo. Crie 2 parágrafos neste resumo.",
                Model = "text-davinci-003"
            });

            if (completionResult.Successful)
            {
                var choice = completionResult.Choices.FirstOrDefault();
                if (choice != null) { return choice.Text; }
                return "Nenhuma resposta encontrada";
            }

            return $"{completionResult.Error.Code}: {completionResult.Error.Message}";
        }

        public async Task<string> GerarImagem(string Destino)
        {
            var completionResult = await Service.Image.CreateImage(new ImageCreateRequest()
            {
                Prompt = Destino,
                N = 1,
                Size = StaticValues.ImageStatics.Size.Size512,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url
            });

            if (completionResult.Successful)
            {
                var choice = completionResult.Results.FirstOrDefault();
                if (choice != null) { return choice.Url; }
                else { return "Nenhuma imagem foi encontrada."; }
            }

            return $"{completionResult.Error.Code}: {completionResult.Error.Message}";
        }
    }
}
