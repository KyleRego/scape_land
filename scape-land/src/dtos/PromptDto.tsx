import OptionDto from "./OptionDto";

export default interface PromptDto {
    text: string;
    options: OptionDto[];
}
